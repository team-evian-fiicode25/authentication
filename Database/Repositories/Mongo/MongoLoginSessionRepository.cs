using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;
using MongoDB.Driver;

namespace Fiicode25Auth.Database.Repositories.Mongo;

public class MongoLoginSessionRepository : BaseMongoRepository<LoginSessionWith2FAData, LoginSession>, ILoginSessionRepository
{
    public override IEnumerable<LoginSessionWith2FAData> All()
        => base.All().Where(ls => _ifValid(ls) != null);

    public async override Task<LoginSessionWith2FAData?> ById(Guid id) 
        => _ifValid(await base.ById(id));

    public async Task<LoginSessionWith2FAData?> ByToken(string token)
        => _ifValid(
                await _db.Find(_filter.Eq("LoginSession.SecureIdentifier", token))
                .FirstOrDefaultAsync());

    public async Task<LoginSessionWith2FAData> Commit(LoginSession obj)
    {
        obj = _stampObject(obj);
        var inDb = await ById(obj.Id);

        if (inDb == null)
        {
            var withLoginData = await _getLoginData(obj);
            await _db.InsertOneAsync(withLoginData);
            return withLoginData;
        }

        var updatedObject = new LoginSessionWith2FAData()
        {
            LoginSession = obj,
            Email = inDb.Email,
            PhoneNumber = inDb.PhoneNumber
        };


        await _db.ReplaceOneAsync(
                _filter.Eq(l => l.LoginSession.Id, obj.Id),
                updatedObject);

        return updatedObject;
    }

    private LoginSessionWith2FAData? _ifValid(LoginSessionWith2FAData? obj)
        => obj != null && obj.LoginSession.Expiration > DateTime.UtcNow ? obj : null;

    private async Task<LoginSessionWith2FAData> _getLoginData(LoginSession obj)
    {
        var login = await _loginRepository.ById(obj.LoginId);
        if (login == null)
        {
            throw new DanglingReferenceException();
        }


        return new()
        {
            LoginSession = obj,
            Email = login.Email,
            PhoneNumber = login.PhoneNumber
        };
    }

    public MongoLoginSessionRepository(IMongoCollection<LoginSessionWith2FAData> collection,
                                       ILoginRepository loginRepository)
        : base(collection)
    {
        _loginRepository = loginRepository;
    }

    ILoginRepository _loginRepository;
}
