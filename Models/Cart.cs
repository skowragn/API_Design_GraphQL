namespace BookstoreGraphQL.Models;
public class Cart
{
    public int CartId { get; set; }
    public string? UserId { get; set; }
    public IEnumerable<CartItem> Items { get; set; } = []; 
}
