using BookstoreGraphQL.Models;
using GraphQL.Types;

namespace BookstoreGraphQL.GraphQL.Types;
public sealed class CartInputObject : InputObjectGraphType<Cart>
{
    public CartInputObject()
    {
        Name = "CartInput";
        Description = "New Cart for user";

        Field(m => m.CartId, type: typeof(IntGraphType)).Description("Identifier of the cart");
        Field(m => m.UserId).Description("User Id - owner of cart");
    }
}