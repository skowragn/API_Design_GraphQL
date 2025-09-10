using BookstoreGraphQL.Database;
using BookstoreGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
        var cart = await _context.Carts
                   .Include(b => b.Items)
                   .FirstOrDefaultAsync(m => m.CartId == cartId) 
                   ?? throw new KeyNotFoundException($"Cart with ID {cartId} not found.");

        cartItem.CartId = cartId;
        cartItem.BookId = cartItem.BookId;

        var book = await _context.Books
                   .Include(b => b.Authors)
                   .FirstOrDefaultAsync(m => m.BookId == cartItem.BookId) 
                   ?? throw new KeyNotFoundException($"Cart with ID {cartId} not found."); 

        cartItem.Book = book;
        cartItem.Cart = cart;
        _context.CartItems.Add(cartItem);
        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task<Cart> AddCartAsync(Cart newCart)
    {
        var cart = await _context.Carts.Include(b => b.Items).FirstOrDefaultAsync(m => m.CartId == newCart.CartId);
           
        if (cart != null)
        {
            throw new InvalidOperationException($"Cart with ID {newCart.CartId} already exists.");
        }

        await _context.Carts.AddAsync(newCart);
        await _context.SaveChangesAsync();

        return newCart;
    }

    public async Task<CartItem> DeleteCartItemFromCartAsync(int cartId, int cartItemId)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(m => m.CartId == cartId);
        if (cart != null)
        {
            var cartItem = cart.Items.FirstOrDefault(i => i.CartItemId == cartItemId);

            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                await _context.SaveChangesAsync();
                return cartItem;
            }
            else
            {
                throw new ArgumentException("Cart item not found", nameof(cartItemId));
            }
        }

        throw new ArgumentException("Cart not found", nameof(cartId));
    }

    public async Task<Cart> DeleteCartAsync(int cartId)
    {
        var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(m => m.CartId == cartId);
        if (cart != null)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        return new Cart();
    }
}