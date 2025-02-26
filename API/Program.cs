using Fiicode25Auth.API.Types;
using Microsoft.AspNetCore;

/// Exposes <c>Query</c> and <c>Mutation</c> through
/// a GraphQL API on http://0.0.0.0:5095/graphql
///
/// While this API isn't accesible to the user and
/// doesn't provide authorization, it MUST NOT leak
/// sensitive info such as password hashes or secrets
/// that do not concern other services
WebHost
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<ObjectType<QueryableLogin>>())
    .Configure(builder =>
        builder
            .UseRouting()
            .UseEndpoints(e => e.MapGraphQL()))
    .Build()
    .Run();
