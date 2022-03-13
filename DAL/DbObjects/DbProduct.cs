using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    public class DbProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
        public string? ImgURL { get; set; }

        public int CategoryID { get; set; }
        public DbCategory Category { get; set; }

        /*public List<int> ReviewIDs { get; set; }
        public List<DbReview> Reviews { get; set; }*/
    }
}
