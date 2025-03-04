namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public class LoginSession : ITimestamped, IIdentified
{
    public Guid LoginId {get; set;}

    public required string SecureIdentifier {get; set;}

    public string? EmailToken {get; set;}
    public string? SMSCode {get; set;}

    public DateTime Expiration {get; set;}

    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public class LoginSessionWith2FAData
{
    public required LoginSession LoginSession {get; set;}
    public Email? Email {get; set;}
    public PhoneNumber? PhoneNumber {get; set;}
}
