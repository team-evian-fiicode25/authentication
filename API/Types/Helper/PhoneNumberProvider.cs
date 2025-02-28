using Fiicode25Auth.API.Types.Helper.Abstract;

namespace Fiicode25Auth.API.Types.Helper;

public class PhoneNumberProvider : IPhoneNumberProvider
{
    public IPhoneNumber New(string phoneNumber)
        => new PhoneNumber(phoneNumber);

    public IPhoneNumber FromDBO(Database.DBObjects.PhoneNumber phoneNumber)
        => new PhoneNumber(phoneNumber.Number, phoneNumber.VerifyCode);

    public Database.DBObjects.PhoneNumber ToDBO(IPhoneNumber phoneNumber) => new()
    {
        Number=phoneNumber.Number,
        VerifyCode=phoneNumber.VerifyCode
    };
        
}

