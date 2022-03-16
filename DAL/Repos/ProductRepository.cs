using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.DbObjects;
using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Profiles;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ShopContext db): base(db){ }

        public override void AddProfiles(IMapperConfigurationExpression config)
        {
            config.AddProfile<MappingProfile>();
        }

        public List<DbProduct> GetAllProducts()
        {
            return db.Products
                .Include(p => p.Category)
                .ToList();
        }

        public DbProduct? GetByID(int ID)
        {
            return db.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ID == ID);
        }

        public List<DbProduct> GetProductsByName(string name)
        {
            return db.Products
                .Include(p => p.Category)
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
    }
}
