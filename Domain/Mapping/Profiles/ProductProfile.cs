using AutoMapper;
using Domain.Models;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListItem>();
            CreateMap<Product, ProductDetails>();
        }
    }
}
