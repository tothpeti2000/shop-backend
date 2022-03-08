using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public Product(int Id, string name, double price, int stock, string category, List<int> reviewIDs)
        {
            this.ID = Id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Category = category;
            this.ReviewIDs = reviewIDs;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public List<int>? ReviewIDs { get; set; }

    }
}
