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
        private readonly ICartRepository _cartRepository;
        public MutationObject(IBookstoreRepository bookstoreRepository, ICartRepository cartRepository)
        {
            _bookstoreRepository = bookstoreRepository;
            _cartRepository = cartRepository;
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
					var bookId = context.GetArgument<int>("bookId");
					var author = context.GetArgument<Author>("author");
					return await _bookstoreRepository.AddAuthorToBookAsync(bookId, author);
				})
			});

            AddField(new FieldType
            {
                Name = "deleteAuthor",
                Description = "Delete author from book.",
                Type = typeof(BookObject),
                Arguments = new QueryArguments
                (
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "bookId",
                        Description = "The id of the book."
                    },
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "authorId",
                        Description = "The id of author to remove."
                    }
                ),
                Resolver = new FuncFieldResolver<object>(async context =>
                {
                    var bookId = context.GetArgument<int>("bookId");
                    var authorId = context.GetArgument<int>("authorId");
                    return await _bookstoreRepository.DeleteAuthorFromCartAsync(bookId, authorId);
                })
            });

            AddField(new FieldType
            {
                Name = "addCart",
                Description = "Add cart for user.",
                Type = typeof(CartObject),
                Arguments = new QueryArguments
                (
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "cartId",
                        Description = "The id of the cart."
                    },
                    new QueryArgument<NonNullGraphType<CartInputObject>>
                    {
                        Name = "CartInput",
                        Description = "New Cart for user."
                    }
                ),
                Resolver = new FuncFieldResolver<object>(async context =>
                {
                    var cart = context.GetArgument<Cart>("cart");
                    return await _cartRepository.AddCartAsync(cart);
                })
            });
            AddField(new FieldType
            {
                Name = "addItemToCart",
                Description = "Add cart for user.",
                Type = typeof(CartObject),
                Arguments = new QueryArguments
               (
                   new QueryArgument<NonNullGraphType<IntGraphType>>
                   {
                       Name = "cartId",
                       Description = "The id of the cart."
                   },
                   new QueryArgument<NonNullGraphType<CartItemInputObject>>
                   {
                       Name = "CartItemInput",
                       Description = "New Cart for user."
                   }
               ),
                Resolver = new FuncFieldResolver<object>(async context =>
                {
                    var cartItem = context.GetArgument<CartItem>("cartItem");
                    var cartId = context.GetArgument<int>("cartId");
                    return await _cartRepository.AddCartItemToCartAsync(cartId, cartItem);
                })
            });

            AddField(new FieldType
            {
                Name = "deleteCart",
                Description = "Delete cart for user.",
                Type = typeof(CartObject),
                Arguments = new QueryArguments
                (
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "cartId",
                        Description = "The id of the cart."
                    }

                ),
                Resolver = new FuncFieldResolver<object>(async context =>
                {
                    var id = context.GetArgument<int>("cartId");
                    return await _cartRepository.DeleteCartAsync(id);
                })
            });

            AddField(new FieldType
            {
                Name = "deleteCartItemFromCart",
                Description = "Delete cart item from the user's cart.",
                Type = typeof(CartItemObject),
                Arguments = new QueryArguments
                (
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "cartId",
                        Description = "The id of the cart."
                    },
                    new QueryArgument<NonNullGraphType<IntGraphType>>
                    {
                        Name = "cartItemId",
                        Description = "The id of the cart item."
                    }

                ),
                Resolver = new FuncFieldResolver<object>(async context =>
                {
                    var cartId = context.GetArgument<int>("cartId");
                    var cartItemId = context.GetArgument<int>("cartItemId");
                    return await _cartRepository.DeleteCartItemFromCartAsync(cartId, cartItemId);
                })
            });
        }
	}
}
