using Domain.Models;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product? GetByID(int ID);
        public ProductDetails? GetProductDetails(int ID);
        public List<ProductListItem> GetProductList();
        public List<ProductListItem> GetProductsByName(string name);
        public double GetMaxPrice();
        public bool AddToCart(int ID);
    }
}
