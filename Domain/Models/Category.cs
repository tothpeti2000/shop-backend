using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ParentCategoryID { get; set; }
        public Category ParentCategory { get; set; }
    }
}
