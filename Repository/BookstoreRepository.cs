using Microsoft.EntityFrameworkCore;
using BookstoreGraphQL.Database;
using BookstoreGraphQL.Models;

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
            var book = await _context.Books.Where(m => m.BookId == bookId).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Book with ID {bookId} not found.");
            book.AddAuthor(author);
            await _context.SaveChangesAsync();
            return book;
        }
}
