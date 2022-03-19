using AutoMapper;
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
    public class ProductService: BaseService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository): base()
        {
            this.repository = repository;
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
