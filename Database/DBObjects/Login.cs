namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public class Login : ITimestamped, IIdentified
{
    public required string PasswordHash {get; set;}

    public string? UserName {get; set;}
    public Email? Email {get; set;}
    public PhoneNumber? PhoneNumber {get; set;}

    public List<SessionToken> SessionTokens {get; set;} = new();

    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public class Email
{
    public required string Address {get; set;}

    public string? VerifyToken {get; set;}
    public required bool IsVerified {get; set;}
}

public class PhoneNumber
{
    public required string Number {get; set;}

    public string? VerifyCode {get; set;}
    public required bool IsVerified {get; set;}
}

public class SessionToken
{
    public required string Token {get; set;}
    public DateTime Expiration {get; set;}
}
