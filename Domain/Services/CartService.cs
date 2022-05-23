using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CartService
    {
        private readonly ICartRepository repository;

        public CartService(ICartRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddItemToCart(int productID, int amount, string userID)
        {
            await repository.AddItemToCart(productID, amount, userID);
        }

        public async Task<List<CartItem>> GetCartItems(string userID)
        {
            return await repository.GetCartItems(userID);
        }

        public async Task UpdateCartItemAmount(int cartItemID, int amount)
        {
            await repository.UpdateCartItemAmount(cartItemID, amount);
        }

        public async Task DeleteCartItem(int cartItemID)
        {
            await repository.DeleteCartItem(cartItemID);
        }
    }
}
