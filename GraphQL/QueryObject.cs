using BookstoreGraphQL.GraphQL.Types;
using BookstoreGraphQL.Repository;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BookstoreGraphQL.GraphQL;

public class QueryObject : ObjectGraphType<object>
{
   private readonly IBookstoreRepository _bookstoreRepository;
   private readonly ICartRepository _cartRepository;
    public QueryObject(IBookstoreRepository bookstoreRepository, ICartRepository cartRepository)
   {
      _bookstoreRepository = bookstoreRepository;
      _cartRepository = cartRepository;
       Init();
   }
		
  
	private void Init()
	{
        AddField(new FieldType
        {
            Name = "books",
            Type = typeof(ListGraphType<BookObject>),
            Resolver = new FuncFieldResolver<object>(async context =>
            {
                return await _bookstoreRepository.GetBooksAsync();
            })
        });

        AddField(new FieldType
        {
            Name = "book",
            Type = typeof(BookObject),
            Arguments = new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>>
                {
                    Name = "bookId",
                }
            ),
            Resolver = new FuncFieldResolver<object>(async context =>
            {
                return await _bookstoreRepository.GetBookByIdAsync(context.GetArgument<int>("bookId"));
            })
        });

        AddField(new FieldType
        {
            Name = "cart",
            Type = typeof(CartObject),
            Arguments = new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>>
                {
                    Name = "cartId",
                }
            ),
            Resolver = new FuncFieldResolver<object>(async context =>
            {
                return await _cartRepository.GetCartByIdAsync(context.GetArgument<int>("cartId"));
            })
        });

        AddField(new FieldType
        {
            Name = "carts",
            Type = typeof(ListGraphType<CartObject>),
            Resolver = new FuncFieldResolver<object>(async context =>
            {
                return await _cartRepository.GetCartsAsync();
            })
        });

    }
}
