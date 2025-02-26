using Fiicode25Auth.API.Types;
using Fiicode25Auth.Database;
using Microsoft.AspNetCore;

Provider.Database.Logins.Commit(Login.FromCredentials("Marius", "prostu123"));
Provider.Database.Logins.Commit(Login.FromCredentials("Elena", "mieImiPlacePlacinta"));
Provider.Database.Logins.Commit(Login.FromCredentials("Cristi", "cartof"));

WebHost
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddType<ObjectType<QueryableLogin>>())
    .Configure(builder =>
        builder
            .UseRouting()
            .UseEndpoints(e => e.MapGraphQL()))
    .Build()
    .Run();
