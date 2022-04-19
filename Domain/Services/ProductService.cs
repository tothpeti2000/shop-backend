using Domain.Mapping.Profiles;
using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Models.QueryParams.Paging;
using Domain.Models.QueryParams.SortFilter;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository repository;
        private readonly Mapper<ProductProfile> mapper;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResponse<ProductListItem>> GetProductListAsync(PagingParams pagingParams, string? name, SortFilterParams sortFilterParams)
        {
            return await repository.GetProductsPagedAsync(pagingParams, name, sortFilterParams);
        }

        public async Task<ProductDetails?> GetProductDetailsAsync(int ID)
        {
            return await repository.GetDetailsByIDAsync(ID);
        }

        public async Task<double> GetMaxPriceAsync()
        {
            return await repository.GetMaxPriceAsync();
        }
    }
}
