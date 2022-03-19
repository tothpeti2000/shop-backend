using AutoMapper;
using Domain.Models;
using Domain.Models.CategoryDTOs;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListItem>();
            CreateMap<Product, ProductDetails>();
            CreateMap<Category, CategoryNode>();
        }
    }
}
