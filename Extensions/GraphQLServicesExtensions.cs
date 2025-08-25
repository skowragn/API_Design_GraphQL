using BookstoreGraphQL.GraphQL;
using GraphQL;
using System.Reflection;

namespace BookstoreGraphQL.Extensions;

public static class GraphQLServicesExtensions
{
    public static IServiceCollection AddGraphQLServices(this IServiceCollection services, bool isDevelopment)
    {
        services.AddGraphQL(options =>
        {
            options.AddErrorInfoProvider(o => o.ExposeExceptionDetails = isDevelopment);
            options.AddSchema<BookstoreSchema>();
            options.AddGraphTypes(Assembly.GetExecutingAssembly());
            options.AddDataLoader();
            options.AddSystemTextJson();
        });

        return services;
    }

}