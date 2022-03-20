using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    internal class DbCart
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public DbUser Customer { get; set; }

        public List<DbCartItem> Items { get; set; }
    }
}
