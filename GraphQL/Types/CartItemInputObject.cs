using BookstoreGraphQL.Models;
using GraphQL.Types;

namespace BookstoreGraphQL.GraphQL.Types;

public sealed class CartItemInputObject : InputObjectGraphType<CartItem>
{
    public CartItemInputObject()
    {
        Name = "CartItemInput";
        Description = "A cart item per user";

        Field(m => m.CartItemId, type: typeof(IntGraphType)).Description("Identifier of the cart item");
        Field(m => m.Quantity, type: typeof(IntGraphType)).Description("Quentity of this kind book");
        Field(m => m.Price, type: typeof(DecimalGraphType)).Description("Price of the book");
        Field(r => r.CartId, type: typeof(IntGraphType)).Description("Cart Id");
        Field(m => m.BookId, type: typeof(IntGraphType)).Description("Identifier of the book assiged to cart item");
    }
}