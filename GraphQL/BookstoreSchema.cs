using GraphQL.Types;

namespace BookstoreGraphQL.GraphQL;

	public class BookstoreSchema : Schema
	{
		public BookstoreSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
		{
			Query = query;
			Mutation = mutation;
		}
	}