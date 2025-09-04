namespace BookstoreGraphQL.Models;
public class Cart
{
    public int CartId { get; set; }
    public string? UserId { get; set; }
    public ICollection<CartItem> Items { get; } = [];

    public void AddItem(CartItem cartItem)
    {
        Items.Add(cartItem);
    }
}
