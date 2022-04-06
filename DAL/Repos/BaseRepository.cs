using AutoMapper;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public abstract class BaseRepository
    {
        protected readonly ShopContext db;
        //protected readonly Domain.Services.Mapper mapper;

        protected BaseRepository(ShopContext db)
        {
            this.db = db;
        }
    }
}
