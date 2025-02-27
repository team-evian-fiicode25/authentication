using Fiicode25Auth.API.Configuration;
using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.Types;
using Fiicode25Auth.Database.DBs;
using Fiicode25Auth.Database.DBs.Abstract;
using Microsoft.AspNetCore;

/// Exposes <c>Query</c> and <c>Mutation</c> through
/// a GraphQL API on http://0.0.0.0:5095/graphql
///
/// While this API isn't accesible to the user and
/// doesn't provide authorization, it MUST NOT leak
/// sensitive info such as password hashes or secrets
/// that do not concern other services

var config = new ApplicationConfiguration(WebApplication.CreateBuilder(args).Configuration);

var builder = WebHost
    .CreateDefaultBuilder(args);

builder
    .ConfigureServices(services =>
        services
            .AddScoped<IApplicationConfiguration, ApplicationConfiguration>()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<ObjectType<QueryableLogin>>());

var dbConfig = config.DatabaseConfig;
if(dbConfig.GetType() == typeof(InMemoryDatabaseConfiguration))
{
    builder.ConfigureServices(s => s.AddSingleton<IDatabaseProvider, InMemoryDatabaseProvider>());
}
else
{
    Console.Error.WriteLine("Unknown database configuration");
    System.Environment.Exit(1);
}

builder
    .Configure(builder =>
        builder
            .UseRouting()
            .UseEndpoints(e => e.MapGraphQL()))
    .Build()
    .Run();
