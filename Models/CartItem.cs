namespace BookstoreGraphQL.Models;

public class CartItem
{
    public int CartItemId { get; set; }
    public required Book Book { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } 
}
