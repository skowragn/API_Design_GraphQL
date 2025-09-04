using BookstoreGraphQL.Database;
using BookstoreGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreGraphQL.Repository;

	public class CartRepository : ICartRepository
	{
		private readonly BookstoreContext _context;

		public CartRepository(BookstoreContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}
       
        public async Task<List<Cart>> GetCartsAsync()
        {
           return await _context.Carts.AsNoTracking().ToListAsync();
        }

        public async Task<Cart> GetCartByIdAsync(int cartId)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is not initialized.");

            var cart = await _context.Carts.Where(m => m.CartId == cartId).AsNoTracking().FirstOrDefaultAsync();

            return cart ?? throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
        }
        public async Task<Cart> AddCartItemToCartAsync(int cartId, CartItem cartItem)
        {
            var cart = await _context.Carts.Where(m => m.CartId == cartId).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Cart with ID {cartId} not found.");
            cart.AddItem(cartItem);
            await _context.SaveChangesAsync();
            return cart;
        }
}