using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbObjects
{
    public class DbReview
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserID { get; set; }
        public AspNetUser User { get; set; }
    }
}
