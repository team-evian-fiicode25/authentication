namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public struct LoginSession : ITimestamped, IIdentified
{
    public Guid LoginId {get; set;}

    public string SecureIdentifier {get; set;}

    public string? EmailToken {get; set;}
    public string? SMSCode {get; set;}

    public DateTime Expiration {get; set;}

    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public struct LoginSessionWith2FAData
{
    public LoginSession LoginSession {get; set;}
    public Email? Email {get; set;}
    public PhoneNumber? PhoneNumber {get; set;}
}
