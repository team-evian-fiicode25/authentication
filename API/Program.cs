using Fiicode25Auth.API.Configuration;
using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.GraphQL;
using Fiicode25Auth.API.GraphQL.Filters;
using Fiicode25Auth.API.GraphQL.Helpers;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;
using Fiicode25Auth.API.GraphQL.Services;
using Fiicode25Auth.API.GraphQL.Services.Abstract;
using Fiicode25Auth.API.Types.Helper.Login;
using Fiicode25Auth.API.Types.Helper.Login.Abstract;
using Fiicode25Auth.API.Types.Helper.LoginSession;
using Fiicode25Auth.API.Types.Helper.LoginSession.Abstract;
using Fiicode25Auth.API.Types.Queryable.Login;
using Fiicode25Auth.API.Types.Queryable.Login.Abstract;
using Fiicode25Auth.API.Types.Queryable.LoginSession;
using Fiicode25Auth.API.Types.Queryable.LoginSession.Abstract;
using Fiicode25Auth.Database.DBs;
using Fiicode25Auth.Database.DBs.Abstract;

/// Exposes <c>Query</c> and <c>Mutation</c> through
/// a GraphQL API on http://0.0.0.0:5095/graphql
///
/// While this API isn't accesible to the user and
/// doesn't provide authorization, it MUST NOT leak
/// sensitive info such as password hashes or secrets
/// that do not concern other services

var config = new ApplicationConfiguration(WebApplication.CreateBuilder(args).Configuration);

var builder = WebApplication
    .CreateBuilder(args);

builder.Services
        .AddScoped<IApplicationConfiguration, ApplicationConfiguration>()
        .AddScoped<ILoginProvider, LoginProvider>()
        .AddScoped<IEmailProvider, EmailProvider>()
        .AddScoped<IPhoneNumberProvider, PhoneNumberProvider>()
        .AddScoped<IPasswordProvider, PasswordProvider>()
        .AddScoped<IQueryableLoginProvider, QueryableLoginProvider>()
        .AddScoped<AllLoginProviders>()
        .AddScoped<ILoginRetriever, LoginRetriever>()
        .AddScoped<ILoginService, LoginService>()
        .AddScoped<ILoginSessionProvider, NOfMLoginSessionProvider>()
        .AddScoped<IEmail2FAProvider, SolvedEmail2FAProvider>()
        .AddScoped<IPhone2FAProvider, SolvedPhone2FAProvider>()
        .AddScoped<IQueryableLoginSessionProvider, QueryableLoginSessionProvider>()
        .AddScoped<ILoginSessionService, LoginSessionService>()
        .AddScoped<ISecureTokenGenerator, SecureTokenGenerator>()
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddErrorFilter<ExposeExceptionsFilter>()
        .AddErrorFilter<DatabaseExceptionFilter>()
        .AddErrorFilter<ErrorLoggingFilter>()
        .AddType<ObjectType<QueryableLogin>>()
        .AddType<ObjectType<QueryableEmail>>()
        .AddType<ObjectType<QueryablePhoneNumber>>()
        .AddType<ObjectType<QueryableLoginSession>>();

var dbConfig = config.DatabaseConfig;
if(dbConfig.GetType() == typeof(InMemoryDatabaseConfiguration))
{
    builder.Services.AddSingleton<IDatabaseProvider, InMemoryDatabaseProvider>();
}
else
{
    Console.Error.WriteLine("Unknown database configuration");
    System.Environment.Exit(1);
}

var app = builder.Build();
app.UseRouting()
   .UseEndpoints(e => e.MapGraphQL());

await app.RunWithGraphQLCommandsAsync(args);
