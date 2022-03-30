﻿using DAL.DbObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShopContext: IdentityDbContext<DbUser>
    {
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbCategory> Categories { get; set; }
        public DbSet<DbReview> Reviews { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureProducts(modelBuilder);
            ConfigureCategories(modelBuilder);
            ConfigureReviews(modelBuilder);
        }

        private void ConfigureProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbProduct>()
                .ToTable("Product");

            modelBuilder.Entity<DbProduct>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<DbProduct>()
                .HasOne(p => p.Category)
                .WithMany();
        }

        private void ConfigureCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbCategory>()
                .ToTable("Category");

            modelBuilder.Entity<DbCategory>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<DbCategory>()
                .HasOne(c => c.ParentCategory)
                .WithMany();
        }

        private void ConfigureReviews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbReview>()
                .ToTable("Review");

            modelBuilder.Entity<DbReview>()
                .HasKey(r => r.ID);

            modelBuilder.Entity<DbReview>()
                .HasOne(r => r.User)
                .WithMany();

            modelBuilder.Entity<DbReview>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews);
        }
    }
}
