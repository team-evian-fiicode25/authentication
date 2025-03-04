using Fiicode25Auth.Database.DBs.Abstract;
using Fiicode25Auth.Database.Repositories.Abstract;
using Fiicode25Auth.Database.Repositories.Mongo;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Fiicode25Auth.Database.DBs;

public class MongoDatabase : IDatabase
{
    public ILoginRepository Logins => new MongoLoginRepository(
            _db.GetCollection<DBObjects.Login>("logins"));

    public ILoginSessionRepository LoginSessions => new MongoLoginSessionRepository(
            _db.GetCollection<DBObjects.LoginSessionWith2FAData>("login_sessions"),
            Logins);

    public MongoDatabase(IMongoDatabase db)
    {
        _registerSerializer();
        _db = db;
    }

    private static void _registerSerializer()
    {
        if (_registeredSerializer)
            return;

        BsonSerializer.RegisterSerializer(
                new GuidSerializer(GuidRepresentation.Standard));
        _registeredSerializer = true;
    }
    private static bool _registeredSerializer = false;

    private IMongoDatabase _db;
}

