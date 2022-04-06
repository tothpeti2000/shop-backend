using Domain.Mapping.Profiles;
using Domain.Models;
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

        public async Task<PagedResponse<ProductListItem>> GetProductList(int page, int count)
        {
            return await repository.GetAllProducts(page, count);
        }

        public List<ProductListItem> GetProductsByName(string name)
        {
            var products = repository.GetProductsByName(name);

            return mapper.Map<List<Product>, List<ProductListItem>>(products);
        }

        public async Task<ProductDetails?> GetProductDetails(int ID)
        {
            return await repository.GetDetailsByID(ID);
        }

        public double GetMaxPrice()
        {
            return repository.GetMaxPrice();
        }
    }
}
