using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;

namespace Fiicode25Auth.API.GraphQL;

public class Mutation 
{
    public Task<IQueryableLogin> CreateLogin(string? username,
                                                   string? email,
                                                   string? phoneNumber,
                                                   string password,
                                                   ILoginService loginService)
        => loginService.Create(password, username, email, phoneNumber);

    public Task<IQueryableLogin?> RemoveLogin(string? id,
                                              string? username,
                                              string? email,
                                              string? phone,
                                              string? sessionToken,
                                              ILoginService loginService)
        => loginService.Remove(id, username, email, phone, sessionToken);

    public Task<IQueryableLoginSession> LogInWithPassword(string? id,
                                                          string? username,
                                                          string? email,
                                                          string? phone,
                                                          string password,
                                                          ILoginSessionService loginSessionService)
        => loginSessionService.LogInWithPassword(password, id, username, email, phone);

    public Task<IEmailVerificationDTO> RequestEmailVerification(string? id,
                                                                string? username,
                                                                string? email,
                                                                string? phone,
                                                                string? sessionToken,
                                                                ILoginService loginService)
        => loginService.RequestEmailVerification(id, username, email, phone, sessionToken);

    public Task<IQueryableLogin> VerifyEmail(string verificationToken,
                                             string? id,
                                             string? username,
                                             string? email,
                                             string? phone,
                                             string? sessionToken,
                                             ILoginService loginService)
        => loginService.VerifyEmail(verificationToken, id, username, email, phone, sessionToken);

    public Task<IPhoneVerificationDTO> RequestPhoneNumberVerification(string? id,
                                                                      string? username,
                                                                      string? email,
                                                                      string? phone,
                                                                      string? sessionToken,
                                                                      ILoginService loginService)
        => loginService.RequestPhoneNumberVerification(id, username, email, phone, sessionToken);

    public Task<IQueryableLogin> VerifyPhoneNumber(string verificationCode,
                                                   string? id,
                                                   string? username,
                                                   string? email,
                                                   string? phone,
                                                   string? sessionToken,
                                                   ILoginService loginService)
        => loginService.VerifyPhoneNumber(verificationCode, id, username, email, phone, sessionToken);
}
