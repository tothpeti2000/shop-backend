using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public User Customer { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
