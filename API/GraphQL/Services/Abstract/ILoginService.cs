using Fiicode25Auth.API.Types.Queryable.Login.Abstract;

namespace Fiicode25Auth.API.GraphQL.Services.Abstract;

public interface ILoginService
{
    Task<IQueryableLogin?> Get(string? id = null,
                               string? username = null,
                               string? email = null,
                               string? phone = null,
                               string? sessionToken = null);

    Task<IEmailVerificationDTO> RequestEmailVerification(string? id = null,
                                                         string? username = null,
                                                         string? email = null,
                                                         string? phone = null,
                                                         string? sessionToken = null);

    Task<IQueryableLogin> VerifyEmail(string verificationToken,
                                      string? id = null,
                                      string? username = null,
                                      string? email = null,
                                      string? phone = null,
                                      string? sessionToken = null);

    Task<IPhoneVerificationDTO> RequestPhoneNumberVerification(string? id = null,
                                                               string? username = null,
                                                               string? email = null,
                                                               string? phone = null,
                                                               string? sessionToken = null);

    Task<IQueryableLogin> VerifyPhoneNumber(string verifyCode,
                                            string? id = null,
                                            string? username = null,
                                            string? email = null,
                                            string? phone = null,
                                            string? sessionToken = null);

    Task<IQueryableLogin> Create(string password,
                                 string? username = null,
                                 string? email = null,
                                 string? phoneNumber = null);

    Task<IQueryableLogin?> Remove(string? id = null,
                                  string? username = null,
                                  string? email = null,
                                  string? phone = null,
                                  string? sessionToken = null);
}
