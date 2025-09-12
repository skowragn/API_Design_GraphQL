using Microsoft.EntityFrameworkCore;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.Database
{
	public class BookstoreContext(DbContextOptions<BookstoreContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
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
                     AuthorId = 5,
                     FullName = "Paulo Coelho",
                     BookId = 1
                 }
             );

            modelBuilder.Entity<Author>()
                        .HasOne<Book>()
                        .WithMany(b => b.Authors)
                        .HasForeignKey(a => a.BookId);


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Isbn = "978-3-16-148410-0",
                    Title = "The Little Prince",
                    Description = "A novella and the most famous work of French writer Antoine de Saint-Exupéry.",
                    CartItemId = 1
                },
                new Book
                {
                    BookId = 2,
                    Isbn = "978-0-06-112241-5",
                    Title = "One Hundred Years of Solitude",
                    Description = "A novel by Colombian author Gabriel García Márquez, first published in 1967.",
                    CartItemId = 2
                },
                new Book
                {
                    BookId = 3,
                    Isbn = "978-0-14-143960-0",
                    Title = "A Tale of Two Cities",
                    Description = "A historical novel by Charles Dickens, set in London and Paris before and during the French Revolution.",
                    CartItemId = 3
                },
                new Book
                {
                    BookId = 4,
                    Isbn = "978-0-06-231500-7",
                    Title = "The Alchemist",
                    Description = "A novel by Brazilian author Paulo Coelho, originally published in Portuguese in 1988.",
                    CartItemId = 4
                },
                new Book
                {
                    BookId = 5,
                    Isbn = "978-0-14-044913-6",
                    Title = "The Count of Monte Cristo",
                    Description = "An adventure novel by French author Alexandre Dumas, first published in 1844.",
                    CartItemId = 5
                }
            );

            modelBuilder.Entity<Book>().Navigation(e => e.Authors).AutoInclude();

            modelBuilder.Entity<Cart>().HasData(
                   new Cart
                   {
                       CartId = 1,
                       UserId = "user1",
                   },
                    new Cart
                    {
                        CartId = 2,
                        UserId = "user2"
                    },
                     new Cart
                     {
                         CartId = 3,
                         UserId = "user3"
                     });


            modelBuilder.Entity<CartItem>().Navigation(e => e.Book).AutoInclude();

            modelBuilder.Entity<CartItem>().HasData(
                    new CartItem
                    {
                        CartItemId = 1,
                        Quantity = 2,
                        Price = 10.99m,
                        CartId = 1,
                        BookId = 1
                    },
                    new CartItem
                    {
                        CartItemId = 2,
                        Quantity = 10,
                        Price = 66.99m,
                        CartId = 2,
                        BookId = 2
                    },
                    new CartItem
                    {
                        CartItemId = 3,
                        Quantity = 10,
                        Price = 66.99m,
                        CartId = 3,
                        BookId = 3
                    },
                    new CartItem
                    {
                        CartItemId = 4,
                        Quantity = 10,
                        Price = 66.99m,
                        CartId = 3,
                        BookId = 4
                    },
                    new CartItem
                    {
                        CartItemId = 5,
                        Quantity = 10,
                        Price = 66.99m,
                        CartId = 3,
                        BookId = 5
                    });

            modelBuilder.Entity<CartItem>()
                       .HasOne<Cart>()
                       .WithMany(b => b.Items)
                       .HasForeignKey(a => a.CartId);


            modelBuilder.Entity<Cart>().Navigation(e => e.Items).AutoInclude();

            modelBuilder.Entity<CartItem>()
                        .HasOne(ci => ci.Book)
                        .WithMany()
                        .HasForeignKey(ci => ci.BookId);
            
            modelBuilder.Entity<CartItem>().Navigation(e => e.Book).AutoInclude();
       }
    }
}