using Domain.Models;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        public Task<PagedResponse<ProductListItem>> GetAllProducts(int page = 1, int count = 10);
        public Task<ProductDetails?> GetDetailsByID(int ID);
        public List<Product> GetProductsByName(string name);
        public double GetMaxPrice();
    }
}
