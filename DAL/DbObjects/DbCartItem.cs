using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    internal class DbCartItem
    {
        public int ID { get; set; }

        public int CartID { get; set; }
        public DbCart Cart { get; set; }
    }
}
