using AutoMapper;
using DAL.DbObjects;
using Domain.Models.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    public class DbCategoryProfile: Profile
    {
        public DbCategoryProfile()
        {
            CreateMap<DbCategory, CategoryNode>();
        }
    }
}
