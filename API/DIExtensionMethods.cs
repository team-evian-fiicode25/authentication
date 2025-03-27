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
using Fiicode25Auth.API.Types.Value;
using Fiicode25Auth.API.Types.Value.Abstract;
using Fiicode25Auth.Database.DBs;
using Fiicode25Auth.Database.DBs.Abstract;
using HotChocolate.Execution.Configuration;

public static class DIExtensionMethods
{
    public static IRequestExecutorBuilder AddGraphQL(this IServiceCollection services)
        => services
            .AddGraphQLServer()
            .AddInMemorySubscriptions()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddSubscriptionType<Subscription>();

    public static IRequestExecutorBuilder AddGraphQLLoginTypes(this IRequestExecutorBuilder services)
        => services
            .AddType<ObjectType<QueryableLogin>>()
            .AddType<ObjectType<QueryableEmail>>()
            .AddType<ObjectType<QueryablePhoneNumber>>();

    public static IRequestExecutorBuilder AddGraphQLLoginSessionTypes(this IRequestExecutorBuilder services)
        => services
            .AddType<ObjectType<QueryableLoginSession>>()
            .AddType<ObjectType<QueryableLoginSession>>()
            .AddType<ObjectType<QueryableSessionToken>>();

    public static IRequestExecutorBuilder AddGraphQLErrorFilters(this IRequestExecutorBuilder services)
        => services
            .AddErrorFilter<ExposeExceptionsFilter>()
            .AddErrorFilter<DatabaseExceptionFilter>()
            .AddErrorFilter<ErrorLoggingFilter>();

    public static IServiceCollection AddLoginTypes(this IServiceCollection services, IApplicationConfiguration config)
    { 
        _addUsernameValue(services, config);
        _addPassword(services, config);

        return services
            .AddScoped<ILoginProvider, LoginProvider>()
            .AddScoped<IEmailProvider, EmailProvider>()
            .AddScoped<IPhoneNumberProvider, PhoneNumberProvider>()
            .AddScoped<IQueryableLoginProvider, QueryableLoginProvider>()
            .AddScoped<AllLoginProviders>()
            .AddScoped<ILoginRetriever, LoginRetriever>()
            .AddScoped<ILoginService, LoginService>()
            .AddScoped<ISessionTokenProvider, SessionTokenProvider>()
            .AddScoped<ISessionTokensProvider, SessionTokensProvider>()
            .AddScoped<IQueryableSessionTokenProvider, QueryableSessionTokenProvider>()
            .AddScoped<ISessionService, SessionService>();
    }

    public static IServiceCollection AddLoginSessionTypes(this IServiceCollection services)
        => services
            .AddScoped<ILoginSessionProvider, NOfMLoginSessionProvider>()
            .AddScoped<IEmail2FAProvider, SolvedEmail2FAProvider>()
            .AddScoped<IPhone2FAProvider, SolvedPhone2FAProvider>()
            .AddScoped<IQueryableLoginSessionProvider, QueryableLoginSessionProvider>()
            .AddScoped<ILoginSessionService, LoginSessionService>();

    private static void _addUsernameValue(IServiceCollection services, IApplicationConfiguration config)
    {
        var usernameConfig = config.UsernameConfig;

        if (usernameConfig is UnconstrainedUsernameConfiguration)
        {
            services.AddScoped<IUsernameValueProvider, UnconstrainedUsernameValueProvider>();
            return;
        }

        var alphaNumericalUserConfig = usernameConfig as AlphaNumericalUsernameConfiguration;
        if(alphaNumericalUserConfig != null)
        {
            services.AddScoped<IUsernameValueProvider>(provider => 
                    new AlphaNumericalUsernameValueProvider(alphaNumericalUserConfig));
            return;
        }
    }

    private static void _addPassword(IServiceCollection services, IApplicationConfiguration config)
    {
        if(config.PasswordConfig is InsecurePasswordConfiguration)
        {
            services.AddScoped<IPasswordProvider, InsecurePasswordProvider>();
            return;
        }

        if(config.PasswordConfig is BcryptHashedPasswordConfiguration)
        {
            services.AddScoped<IPasswordProvider, InsecurePasswordProvider>();
            return;
        }

        throw new Exception("Unknown password configuration");
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IApplicationConfiguration config)
    {
        var dbConfig = config.DatabaseConfig;
        if (dbConfig is InMemoryDatabaseConfiguration)
        {
            return services.AddSingleton<IDatabaseProvider, InMemoryDatabaseProvider>();
        }

        var mongoConfig = dbConfig as IMongoDatabaseConfiguration;
        if (mongoConfig != null)
        {
            return services.AddSingleton<IDatabaseProvider>(provider =>
                    new MongoDatabaseProvider(mongoConfig.Url, mongoConfig.Database));
        }

        throw new Exception("Unknown database configuration");
    }
}

