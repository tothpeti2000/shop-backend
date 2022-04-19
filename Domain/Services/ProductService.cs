using Domain.Mapping.Profiles;
using Domain.Models;
using Domain.Models.Paging;
using Domain.Models.ProductDTOs;
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

        public async Task<PagedResponse<ProductListItem>> GetProductList(int page, int limit, string? name)
        {
            return await repository.GetProductsPaged(page, limit, name);
        }

        public async Task<ProductDetails?> GetProductDetails(int ID)
        {
            return await repository.GetDetailsByID(ID);
        }

        public async Task<double> GetMaxPrice()
        {
            return await repository.GetMaxPrice();
        }
    }
}
