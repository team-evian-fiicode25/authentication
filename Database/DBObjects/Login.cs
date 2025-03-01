namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public struct Login : ITimestamped, IIdentified
{
    public string PasswordHash {get; set;}

    public string? UserName {get; set;}
    public Email? Email {get; set;}
    public PhoneNumber? PhoneNumber {get; set;}

    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}

public struct Email
{
    public string Address {get; set;}

    /// <value>
    ///     Token to be received in mail, 
    ///     probably encoded in an URL
    /// </value>
    /// <remarks>
    ///     A null value here signifies
    ///     a verified email address
    /// </remarks>
    public string? VerifyToken {get; set;}
}

public struct PhoneNumber
{
    public string Number {get; set;}

    /// <value>Verify code to be sent in SMS</value>
    /// <remarks>
    ///     A null value here signifies
    ///     a verified phone number
    /// </remarks>
    public string? VerifyCode {get; set;}
}
