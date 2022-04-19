using Domain.Models;
using Domain.Models.Paging;
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
        public Task<PagedResponse<ProductListItem>> GetProductsPaged(int page, int limit);
        public Task<ProductDetails?> GetDetailsByID(int ID);
        public List<Product> GetProductsByName(string name);
        public double GetMaxPrice();
    }
}
