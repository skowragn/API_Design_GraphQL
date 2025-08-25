using GraphQL.Types;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.GraphQL.Types
{
	public sealed class AuthorObject : ObjectGraphType<Author>
	{
		public AuthorObject()
		{
			Name = nameof(Author);
			Description = "Author of the book";
			
			Field(r => r.AuthorId, type: typeof(IntGraphType)).Description("author Id");
			Field(r => r.FullName).Description("Name of the author");
			Field(r => r.BookId, type: typeof(IntGraphType)).Description("Book Id");
        }
    }
}