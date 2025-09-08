using GraphQL.Types;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.GraphQL.Types;

public sealed class BookInputObject : InputObjectGraphType<Book>
{
    public BookInputObject()
    {
        Name = "BookInput";
        Description = "Book Input";

        Field(m => m.BookId, type: typeof(IntGraphType)).Description("Identifier of the book");
        Field(m => m.Isbn).Description("Isbn number of the book");
        Field(m => m.Title).Description("Title of the book");
        Field(m => m.Description).Description("Description of the book");
        Field(m => m.CartItemId, type: typeof(IntGraphType)).Description("Identifier of the cart item");
    }
}
