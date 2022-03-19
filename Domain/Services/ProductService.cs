using AutoMapper;
using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Profiles;
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
        private readonly IMapper mapper;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;

            var config = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductProfile>();
            });

            mapper = config.CreateMapper();
        }

        public List<ProductListItem> GetProductList()
        {
            var products = repository.GetAllProducts();

            return mapper.Map<List<Product>, List<ProductListItem>>(products);
        }

        public List<ProductListItem> GetProductsByName(string name)
        {
            var products = repository.GetProductsByName(name);

            return mapper.Map<List<Product>, List<ProductListItem>>(products);
        }

        public ProductDetails? GetProductDetails(int ID)
        {
            var product = repository.GetByID(ID); ;

            return mapper.Map<Product, ProductDetails>(product);
        }

        public double GetMaxPrice()
        {
            return repository.GetMaxPrice();
        }
    }
}
