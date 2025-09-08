using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.Repository
{
	public interface IBookstoreRepository
	{
		Task<List<Book>> GetBooksAsync();
		Task<Book> GetBookByIdAsync(int bookId);
		Task<Book> AddAuthorToBookAsync(int bookId, Author author);
		Task<Book> DeleteAuthorFromCartAsync(int bookId, int authorId);
    }
}
