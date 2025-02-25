namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public readonly struct Login : ITimestamped, IIdentified
{
    public string UserName {get; init;}
    public string PasswordHash {get; init;}

    public Guid Id {get; init;}
    public DateTime CreatedAt {get; init;}
    public DateTime UpdatedAt {get; init;}
}
