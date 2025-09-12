using BookstoreGraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace BookstoreGraphQL.Extensions;

public static class BookstoreDatabaseExtensions
{
    public static IServiceCollection AddBookstoreDatabase(this IServiceCollection services)
    {
       // In- memory database
        services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<BookstoreContext>(context => { context.UseInMemoryDatabase("BookstoreDb"); });


        // server database
        //var connectionString = "server=localhost\\SQLEXPRESS;database=BookstoreDb;Integrated Security=true;TrustServerCertificate=True";
        //services.AddDbContext<BookstoreContext>(options =>
        //                   options.UseSqlServer(connectionString,
        //                   opt => opt.MigrationsAssembly(typeof(BookstoreDatabaseExtensions).Assembly.FullName)));
        return services;
    }
}