using Domain.Models.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ProductDTOs
{
    public class Product
    {
        public Product(int Id, string name, double price, int stock, string description, double averageRating, string? imgURL/*, Category category, List<Review>? reviews*/)
        {
            ID = Id;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            AverageRating = averageRating;
            ImgURL = imgURL;
            //Category = category;
            //Reviews = reviews;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public string? ImgURL { get; set; }
        public Category Category { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}
