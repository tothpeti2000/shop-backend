using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShopContext: DbContext
    {
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbCategory> Categories { get; set; }
        public DbSet<DbReview> Reviews { get; set; }

        public ShopContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = TestDataSeeder.GetProducts();
            var categories = TestDataSeeder.GetCategories();

            modelBuilder.Entity<DbProduct>()
                .ToTable("Product");

            modelBuilder.Entity<DbProduct>()
                .HasOne(p => p.Category);

            /*modelBuilder.Entity<DbProduct>()
                .HasMany(p => p.Reviews);*/

            /*modelBuilder.Entity<DbProduct>()
                .HasData(products);*/

        }
    }
}
