using GraphQL.Types;
using BookstoreGraphQL.Models;


namespace BookstoreGraphQL.GraphQL.Types
{
	public sealed class AuthorInputObject : InputObjectGraphType<Author>
	{
		public AuthorInputObject()
		{
			Name = "AuthorInput";
			Description = "Author of the book";

            Field(r => r.AuthorId, type: typeof(IntGraphType)).Description("author Id");
            Field(r => r.FullName).Description("Name of the author");
        }
	}
}
