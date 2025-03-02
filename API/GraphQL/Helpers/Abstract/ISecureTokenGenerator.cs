namespace Fiicode25Auth.API.GraphQL.Helpers.Abstract;

public interface ISecureTokenGenerator 
{
    string Base64Url128Bytes();
    string RandomDigits6();
}

