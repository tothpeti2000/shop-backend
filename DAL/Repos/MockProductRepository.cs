using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class MockProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product(1, "Product1", 1000, 10, "LEGO"),
                new Product(2, "Product2", 1000, 10, "LEGO"),
                new Product(3, "Product3", 1000, 10, "LEGO")
            };

            return products;
        }
    }
}
