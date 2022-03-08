using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    public class DbCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ParentCategoryID { get; set; }
        public DbCategory ParentCategory { get; set; }
    }
}
