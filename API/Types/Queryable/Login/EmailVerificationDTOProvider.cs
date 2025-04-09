using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class EmailVerificationDTOProvider : IEmailVerificationDTOProvider
{
    public IEmailVerificationDTO FromDBO(Database.DBObjects.Login login)
    {
        if (login.Email == null || login.Email.VerifyToken == null)
            throw new Exception();

        return new EmailVerificationDTO()
        {
            UserId = login.Id.ToString(),
            Username = login.UserName,
            Email = login.Email.Address,
            VerificationToken = login.Email.VerifyToken,
        };
    }
}
