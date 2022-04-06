using AutoMapper;
using DAL.DbObjects;
using Domain.Models.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    public class DbProductProfile: Profile
    {
        public DbProductProfile()
        {
            CreateMap<DbProduct, ProductListItem>();
            CreateMap<DbProduct, ProductDetails>();
        }
    }
}
