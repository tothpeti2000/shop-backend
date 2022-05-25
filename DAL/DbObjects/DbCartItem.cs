using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    public class DbCartItem
    {
        public int ID { get; set; }
        public int Amount { get; set; }

        public int ProductID { get; set; }
        public DbProduct Product { get; set; }

        public int CartID { get; set; }
    }
}
