using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.Repository;

public interface ICartRepository
{
	Task<List<Cart>> GetCartsAsync();
	Task<Cart> GetCartByIdAsync(int cartId);
	Task<Cart> AddCartItemToCartAsync(int cartId, CartItem cartItem);
	Task<Cart> AddCartAsync(Cart cart);
	Task<CartItem> DeleteCartItemFromCartAsync(int cartId, int cartItemId);
	Task<Cart> DeleteCartAsync(int cartId);
}
