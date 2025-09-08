using BookstoreGraphQL.Database;
using BookstoreGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreGraphQL.Repository;

	public class BookstoreRepository : IBookstoreRepository
	{
		private readonly BookstoreContext _context;

		public BookstoreRepository(BookstoreContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is not initialized.");

            var book = await _context.Books.Where(m => m.BookId == bookId).AsNoTracking().FirstOrDefaultAsync();
        
            return book ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");
        }

        public async Task<Book> AddAuthorToBookAsync(int bookId, Author author)
        {
            var book = await _context.Books
                .Include(b => b.Authors) 
                .FirstOrDefaultAsync(m => m.BookId == bookId)
                ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");

            author.BookId = bookId;
           _context.Authors.Add(author);

           await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAuthorFromCartAsync(int bookId, int authorId)
        {
            var book = await _context.Books
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(m => m.BookId == bookId)
                ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");
           
           var author = book.Authors.FirstOrDefault(a => a.AuthorId == authorId);
           
           
          if (author == null)
                throw new KeyNotFoundException($"Author with ID {authorId} not found in book with ID {bookId}.");

        author.BookId = bookId;

        _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return book;
        }
}
