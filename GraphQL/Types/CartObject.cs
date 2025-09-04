using BookstoreGraphQL.GraphQL.Types;
using BookstoreGraphQL.Models;
using GraphQL.Types;

namespace BookstoreGraphQL.GraphQL.Types;
public sealed class CartObject : ObjectGraphType<Cart>
{
    public CartObject()
    {
        Name = nameof(Cart);
        Description = "Cart per user";

        Field(m => m.CartId, type: typeof(IntGraphType)).Description("Identifier of the cart");
        Field(m => m.UserId).Description("User Id - owner of cart");
        Field(m => m.Items, type: typeof(ListGraphType<CartItemObject>)).Resolve(c => c.Source.Items).Description("Cart items per user and cart");
    }

}