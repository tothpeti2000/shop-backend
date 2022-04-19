using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Models.QueryParams.Paging;
using Domain.Models.QueryParams.SortFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        public Task<PagedResponse<ProductListItem>> GetProductsPagedAsync(PagingParams pagingParams, string? query, SortFilterParams sortFilterParams);
        public Task<ProductDetails?> GetDetailsByIDAsync(int ID);
        public Task<double> GetMaxPriceAsync();
    }
}
