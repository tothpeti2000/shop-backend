using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ProductContext: DbContext
    {
        public DbSet<DbProduct> Products { get; set; }

        public ProductContext(DbContextOptions options): base(options) { }
    }
}
