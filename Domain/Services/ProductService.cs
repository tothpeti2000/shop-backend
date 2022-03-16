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
            var dbProducts = repository.GetAllProducts();

            return mapper.Map<List<DbProduct>, List<ProductListItem>>(dbProducts);
        }

        public ProductDetails? GetProductDetails(int ID)
        {
            var product = GetByID(ID);

            return mapper.Map<Product, ProductDetails>(product);
        }

        public double GetMaxPrice()
        {
            return db.Products.Max(p => p.Price);
        }
    }
}
