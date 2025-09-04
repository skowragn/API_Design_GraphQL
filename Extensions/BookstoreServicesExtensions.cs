using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookstoreGraphQL.GraphQL;
using BookstoreGraphQL.Repository;

namespace BookstoreGraphQL.Extensions;

public static class BookstoreServicesExtensions
{
    public static IHostBuilder AddBookstoreServices(this IHostBuilder host)
    {
         host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
           .ConfigureContainer<ContainerBuilder>(containerBuilder =>
           {
               containerBuilder.RegisterType<BookstoreRepository>().As<IBookstoreRepository>().InstancePerLifetimeScope();
               containerBuilder.RegisterType<CartRepository>().As<ICartRepository>().InstancePerLifetimeScope();
               containerBuilder.RegisterType<QueryObject>().AsSelf().SingleInstance().UsingConstructor(typeof(IBookstoreRepository), typeof(ICartRepository));
               containerBuilder.RegisterType<MutationObject>().AsSelf().SingleInstance().UsingConstructor(typeof(IBookstoreRepository), typeof(ICartRepository));
           });

        return host;
    }

}