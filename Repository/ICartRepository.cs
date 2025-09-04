using BookstoreGraphQL.Models;

namespace BookstoreGraphQL.Repository
{
	public interface ICartRepository
	{
		Task<List<Cart>> GetCartsAsync();
		Task<Cart> GetCartByIdAsync(int cartId);
		Task<Cart> AddCartItemToCartAsync(int cartId, CartItem cartItem);
	}
}
