using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ProductDTOs
{
    public class ProductDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public string? ImgURL { get; set; }

        public ProductDetails(int Id, string name, double price, int stock, string description, double averageRating, string? imgURL)
        {
            ID = Id;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            AverageRating = averageRating;
            ImgURL = imgURL;
        }
    }
}
