using AutoMapper;
using DAL.DbObjects;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    public class DbCartProfile: Profile
    {
        public DbCartProfile()
        {
            CreateMap<DbCartItem, CartItem>();
        }
    }
}
