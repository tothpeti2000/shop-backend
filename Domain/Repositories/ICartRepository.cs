using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICartRepository
    {
        public Task AddItemToCart(int productID, int amount, string userID);
        public Task<List<CartItem>> GetCartItems(string userID);
    }
}
