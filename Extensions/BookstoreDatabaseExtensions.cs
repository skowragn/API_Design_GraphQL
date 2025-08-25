using BookstoreGraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace BookstoreGraphQL.Extensions;

public static class BookstoreDatabaseExtensions
{
    public static IServiceCollection AddBookstoreDatabase(this IServiceCollection services)
    {
       services.AddEntityFrameworkInMemoryDatabase()
               .AddDbContext<BookstoreContext>(context => { context.UseInMemoryDatabase("BookstoreDb"); });

        return services;
    }
}