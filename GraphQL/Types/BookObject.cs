using GraphQL.Types;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.GraphQL.Types;

public sealed class BookObject : ObjectGraphType<Book>
{
	public BookObject()
	{
		Name = nameof(Book);
		Description = "A movie in the collection";

		Field(m => m.BookId, type: typeof(IntGraphType)).Description("Identifier of the book");
		Field(m => m.Isbn).Description("Isbn number of the book");
            Field(m => m.Title).Description("Title of the book");
            Field(m => m.Description).Description("Description of the book");
            Field(m => m.Authors, type: typeof(ListGraphType<AuthorObject>)).Resolve(c => c.Source.Authors).Description("Author of the book");
	}
    }
