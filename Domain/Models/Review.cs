using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        public Review(int Id, string text, double rating, DateTime CreatedAt, string userName)
        {
            ID = Id;
            Text = text;
            Rating = rating;
            CreatedAt = CreatedAt;
            UserName = userName;
        }

        public int ID { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
    }
}
