using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using BookstoreGraphQL.GraphQL.Types;
using BookstoreGraphQL.Repository;
using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.GraphQL
{
	public class MutationObject : ObjectGraphType<object>
	{
		private readonly IBookstoreRepository _bookstoreRepository;
        public MutationObject(IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository;
            Init();
        }


        private void Init()
        {
			Name = "Mutations";
			Description = "The base mutation for all the entities in our object graph.";

			AddField(new FieldType
			{
				Name = "addAuthor",
				Description = "Add author to a book.",
				Type = typeof(BookObject),
				Arguments = new QueryArguments
				(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "bookId",
						Description = "The id of the book."
					},
					new QueryArgument<NonNullGraphType<AuthorInputObject>>
					{
						Name = "author",
						Description = "Author of the book"
					}
				),
				Resolver = new FuncFieldResolver<object>(async context =>
				{
					var id = context.GetArgument<int>("bookId");
					var author = context.GetArgument<Author>("author");
					return await _bookstoreRepository.AddAuthorToBookAsync(id, author);
				})
			});
		}
	}
}
