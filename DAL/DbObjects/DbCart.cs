using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    public class DbCart
    {
        public int ID { get; set; }

        public string UserID { get; set; }
        public DbUser User { get; set; }

        public bool Active { get; set; } = true;

        public List<DbCartItem> Items { get; set; }
    }
}
