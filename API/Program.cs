using Fiicode25Auth.API.Configuration;
using Fiicode25Auth.API.Configuration.Abstract;
using Fiicode25Auth.API.GraphQL.Helpers;
using Fiicode25Auth.API.GraphQL.Helpers.Abstract;

/// Exposes <c>Query</c> and <c>Mutation</c> through
/// a GraphQL API on http://0.0.0.0:5095/graphql
///
/// While this API isn't accesible to the user and
/// doesn't provide authorization, it MUST NOT leak
/// sensitive info such as password hashes or secrets
/// that do not concern other services

var builder = WebApplication
    .CreateBuilder(args);

var appConfig = new ApplicationConfiguration(builder.Configuration);

builder.Services
        .AddDatabase(appConfig)
        .AddLoginTypes(appConfig)
        .AddLoginSessionTypes()
        .AddScoped<IApplicationConfiguration, ApplicationConfiguration>()
        .AddScoped<ISecureTokenGenerator, SecureTokenGenerator>()
        .AddGraphQL(appConfig)
        .AddGraphQLErrorFilters()
        .AddGraphQLLoginTypes()
        .AddGraphQLLoginSessionTypes();

var app = builder.Build();
app.UseRouting()
   .UseWebSockets()
   .UseEndpoints(e => e.MapGraphQL());

await app.RunWithGraphQLCommandsAsync(args);
