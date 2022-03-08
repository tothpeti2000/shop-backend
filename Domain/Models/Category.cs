using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public Category(int Id, string name, string parentCategoryName)
        {
            ID = Id;
            Name = name;
            ParentCategoryName = parentCategoryName;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
