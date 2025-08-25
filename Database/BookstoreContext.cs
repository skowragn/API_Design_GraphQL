using Microsoft.EntityFrameworkCore;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.Database
{
	public class BookstoreContext(DbContextOptions<BookstoreContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().OwnsMany(m => m.Authors).HasData(
				new Author
				{
					AuthorId = 1,
					FullName = "Alexandre Dumas",
					BookId = 5

                },
                new Author
                {
                    AuthorId = 2,
                    FullName = "Antoine de Saint-Exupéry",
                    BookId = 1
                },
               new Author
               {
                   AuthorId = 3,
                   FullName = "Gabriel García Márquez",
                   BookId = 2
               },
               new Author
               {
                   AuthorId = 4,
                   FullName = "Charles Dickens",
                   BookId = 3
               },
                new Author
                {
                    AuthorId = 4,
                    FullName = "Paulo Coelho",
                    BookId = 1
                }
			);
			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					BookId = 1,
					Isbn = "978-3-16-148410-0",
					Title = "The Little Prince",
					Description = "A novella and the most famous work of French writer Antoine de Saint-Exupéry."
				},
				new Book 
				{
					BookId = 2,
					Isbn = "978-0-06-112241-5",
					Title = "One Hundred Years of Solitude",
					Description = "A novel by Colombian author Gabriel García Márquez, first published in 1967."
				},
				new Book
                {
					BookId = 3,
					Isbn = "978-0-14-143960-0",
					Title = "A Tale of Two Cities",
					Description = "A historical novel by Charles Dickens, set in London and Paris before and during the French Revolution."
					},
				new Book
                {
					BookId = 4,
					Isbn = "978-0-06-231500-7",
					Title = "The Alchemist",
					Description = "A novel by Brazilian author Paulo Coelho, originally published in Portuguese in 1988."
                },
				new Book
                {
					BookId = 5,
					Isbn = "978-0-14-044913-6",
					Title = "The Count of Monte Cristo",
					Description = "An adventure novel by French author Alexandre Dumas, first published in 1844."
                }
            );
		}
	}
}
