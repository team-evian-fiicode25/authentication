namespace Fiicode25Auth.Database.DBObjects;

using System;
using Abstract;

public struct Login : ITimestamped, IIdentified
{
    public string UserName {get; set;}
    public string PasswordHash {get; set;}

    public Guid Id {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
}
