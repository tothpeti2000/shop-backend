using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }

    public class CartItemToAdd
    {
        public int ProductID { get; set; }
        public int Amount { get; set; }
    }

    public class CartItemToUpdate
    {
        public int ItemID { get; set; }
        public int Amount { get; set; }
    }
}
