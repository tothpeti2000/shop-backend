using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ShopContext: DbContext
    {
        public DbSet<DbProduct> Products { get; set; }

        public ShopContext(DbContextOptions options): base(options) { }
    }
}
