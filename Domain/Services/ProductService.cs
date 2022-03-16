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

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public List<ProductListItem> GetProductList()
        {
            return repository.GetProductList();
        }

        public List<ProductListItem> GetProductsByName(string name)
        {
            return repository.GetProductsByName(name);
        }

        public ProductDetails? GetProductDetails(int ID)
        {
            return repository.GetProductDetails(ID);
        }

        public double GetMaxPrice()
        {
            return repository.GetMaxPrice();
        }
    }
}
