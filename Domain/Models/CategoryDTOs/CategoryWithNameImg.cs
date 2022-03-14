using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Category
{
    public class CategoryWithNameImg
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? ImgURL { get; set; }

        public CategoryWithNameImg(int Id, string name, string? imgURL)
        {
            ID = Id;
            Name = name;
            ImgURL = imgURL;
        }
    }
}
