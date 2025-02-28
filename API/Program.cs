using Fiicode25Auth.API.Configuration;
using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.GraphQL;
using Fiicode25Auth.API.Types.Helper;
using Fiicode25Auth.API.Types.Helper.Abstract;
using Fiicode25Auth.API.Types.Queryable;
using Fiicode25Auth.API.Types.Queryable.Abstract;
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
            .AddScoped<ILoginProvider, LoginProvider>()
            .AddScoped<IEmailProvider, EmailProvider>()
            .AddScoped<IPhoneNumberProvider, PhoneNumberProvider>()
            .AddScoped<IPasswordProvider, PasswordProvider>()
            .AddScoped<IQueryableLoginProvider, QueryableLoginProvider>()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddErrorFilter<DatabaseExceptionFilter>()
            .AddType<ObjectType<QueryableLogin>>()
            .AddType<ObjectType<QueryableEmail>>()
            .AddType<ObjectType<QueryablePhoneNumber>>());

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
