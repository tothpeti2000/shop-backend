﻿using AutoMapper;
using DAL.DbObjects;
using Domain.Models;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DbProduct, Product>();
            CreateMap<Product, ProductDetails>();
            CreateMap<DbCategory, Category>();
            CreateMap<Product, ProductListItem>();
        }
    }
}
