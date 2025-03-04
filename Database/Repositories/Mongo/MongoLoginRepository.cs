using Fiicode25Auth.Database.DBObjects;
using Fiicode25Auth.Database.Exceptions;
using Fiicode25Auth.Database.Repositories.Abstract;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Fiicode25Auth.Database.Repositories.Mongo;

public class MongoLoginRepository : BaseMongoRepository<Login, Login>, ILoginRepository
{
    public async override Task<Login?> ById(Guid id)
        => _filterExpiredSessions(await base.ById(id));

    public async Task<Login?> ByUsername(string username)
        => _filterExpiredSessions(
                await _db.Find(_filter
                    .Eq((login) => login.UserName, username)
                ).FirstOrDefaultAsync());

    public async Task<Login?> ByEmail(string email)
        => _filterExpiredSessions(
                await _db.Find(_filter
                    .Eq("Email.Address", email)
                ).FirstOrDefaultAsync());

    public async Task<Login?> ByPhoneNumber(string phoneNumber)
        => _filterExpiredSessions(
                await _db.Find(_filter
                    .Eq("PhoneNumber.Number", phoneNumber)
                ).FirstOrDefaultAsync());

    public async Task<Login?> BySessionToken(string token)
        => _filterExpiredSessions(
                await _db
                    .AsQueryable()
                    .Where(l => l.SessionTokens.Any(t => t.Token == token))
                    .FirstOrDefaultAsync());


    public async Task<Login> Commit(Login obj)
    {
        obj = _stampObject(obj);
        await _duplicateChecks(obj);

        var inDb = await ById(obj.Id);

        if (inDb == null)
        {
            await _db.InsertOneAsync(obj);
            return obj;
        }

        await _db.ReplaceOneAsync(_filter.Eq(l => l.Id, obj.Id), obj);
        return obj;
    }

    private async Task _duplicateChecks(Login obj)
    {
        var otherLogins = _db.AsQueryable().Where(l => l.Id != obj.Id);


        if (obj.UserName != null &&
                await otherLogins
                .Where(l => l.UserName == obj.UserName)
                .AnyAsync())
            throw new DuplicateUsernameException();

        if (obj.Email != null &&
                await otherLogins
                    .Where(l => l.Email != null &&
                        l.Email.Address == obj.Email.Address)
                    .AnyAsync())
            throw new DuplicateEmailException();

        if (obj.PhoneNumber != null &&
                await otherLogins
                    .Where(l => l.PhoneNumber != null &&
                        l.PhoneNumber.Number == obj.PhoneNumber.Number)
                    .AnyAsync())
            throw new DuplicatePhoneNumberException();
    }

    private Login? _filterExpiredSessions(Login? login)
    {
        if(login == null)
            return null;

        login.SessionTokens = login.SessionTokens
            .Where(st => st.Expiration > DateTime.UtcNow)
            .ToList();

        return login;
    }

    public MongoLoginRepository(IMongoCollection<Login> collection)
        : base(collection)
    {}
}
