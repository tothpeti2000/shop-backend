using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ProductDTOs
{
    public class Product
    {
        public Product(int Id, string name, double price, int stock, string category)
        {
            ID = Id;
            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public List<int>? ReviewIDs { get; set; }

    }
}
