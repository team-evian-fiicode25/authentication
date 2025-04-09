using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.Types.Queryable.Login;

public class PhoneVerificationDTOProvider : IPhoneVerificationDTOProvider
{
    public IPhoneVerificationDTO FromDBO(Database.DBObjects.Login login)
    {
        if (login.PhoneNumber == null || login.PhoneNumber.VerifyCode == null)
            throw new Exception();

        return new PhoneVerificationDTO()
        {
            Username = login.UserName,
            PhoneNumber = login.PhoneNumber.Number,
            VerificationCode = login.PhoneNumber.VerifyCode,
        };
    }
}


