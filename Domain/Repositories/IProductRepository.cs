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
        public Task<PagedResponse<ProductListItem>> GetProductsPagedAsync(int page, int limit, string? name);
        public Task<ProductDetails?> GetDetailsByIDAsync(int ID);
        public Task<double> GetMaxPriceAsync();
    }
}
