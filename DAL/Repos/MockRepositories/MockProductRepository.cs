using Domain.Models.ProductDTOs;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.MockRepositories
{
    /*public class MockProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product(1, "Product1", 1000, 10, "LEGO"),
            new Product(2, "Product2", 1000, 0, "LEGO"),
            new Product(3, "Product3", 1000, 10, "LEGO"),
            new Product(4, "Product4", 1000, 10, "LEGO"),
            new Product(5, "Product5", 1000, 10, "LEGO"),
            new Product(6, "Product6", 1000, 10, "LEGO"),
            new Product(7, "Product7", 1000, 0, "LEGO"),
            new Product(8, "Product8", 1000, 10, "LEGO"),
            new Product(9, "Product9", 1000, 0, "LEGO"),
            new Product(10, "Product10", 1000, 10, "LEGO")
        };

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetByID(int ID)
        {
            return products
                .FirstOrDefault(p => p.ID == ID);
        }

        public bool AddToCart(int ID)
        {
            throw new NotImplementedException();
        }

        public double GetMaxPrice()
        {
            throw new NotImplementedException();
        }

        public ProductDetails GetProductDetails(int ID)
        {
            throw new NotImplementedException();
        }
    }*/
}
