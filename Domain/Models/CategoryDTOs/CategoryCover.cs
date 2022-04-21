using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CategoryDTOs
{
    public class CategoryCover
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? ImgURL { get; set; }
    }
}
