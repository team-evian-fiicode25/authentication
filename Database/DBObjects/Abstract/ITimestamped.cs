namespace Fiicode25Auth.Database.DBObjects.Abstract;

public interface ITimestamped 
{
    DateTime CreatedAt {get;set;}
    DateTime UpdatedAt {get;set;}
}
