using Microsoft.AspNetCore;
 
WebHost
    .CreateDefaultBuilder(args)
    .ConfigureServices(services =>
        services
            .AddGraphQLServer()
            .AddQueryType<Query>())
    .Configure(builder =>
        builder
            .UseRouting()
            .UseEndpoints(e => e.MapGraphQL()))
    .Build()
    .Run();
 
public class Query
{
    public string HelloWorld() 
        => "Hello, world!";
}
