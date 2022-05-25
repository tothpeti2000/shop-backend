using DAL.DbObjects;
using DAL.Profiles;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CartRepository : ICartRepository
    {
        private readonly ShopContext db;
        private readonly Mapper<DbCartProfile> mapper = new();

        public CartRepository(ShopContext db)
        {
            this.db = db;
        }

        public async Task AddItemToCart(int productID, int amount, string userID)
        {
            var dbCart = await db.Carts
                .FirstOrDefaultAsync(c => c.UserID == userID && c.Active);

            if (dbCart == null)
            {
                dbCart = new DbCart
                {
                    UserID = userID,
                };

                await db.Carts.AddAsync(dbCart);
                db.SaveChanges();
            }

            var dbCartItem = await db.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductID == productID && ci.CartID == dbCart.ID);

            if (dbCartItem == null)
            {
                dbCartItem = new DbCartItem
                {
                    ProductID = productID,
                    Amount = amount,
                    CartID = dbCart.ID,
                };

                db.CartItems.Add(dbCartItem);
            } else
            {
                dbCartItem.Amount += amount;
            }

            db.SaveChanges();
        }

        public async Task<List<CartItem>> GetCartItems(string userID)
        {
            var dbCart = await db.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserID == userID && c.Active);

            var dbCartItems = await db.CartItems
                .Where(ci => ci.CartID == dbCart.ID)
                .ToListAsync();

            return mapper.Map<List<DbCartItem>, List<CartItem>>(dbCartItems);
        }

        public async Task UpdateCartItemAmount(int cartItemID, int amount)
        {
            var cartItem = await db.CartItems
                .FirstOrDefaultAsync(ci => ci.ID == cartItemID);

            cartItem.Amount = amount;
            db.SaveChanges();
        }

        public async Task DeleteCartItem(int cartItemID)
        {
            var cartItem = await db.CartItems
                .FirstOrDefaultAsync(ci => ci.ID == cartItemID);

            db.CartItems
                .Remove(cartItem);

            db.SaveChanges();
        }
    }
}
