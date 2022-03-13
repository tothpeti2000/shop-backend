using DAL.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TestDataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopContext(serviceProvider.GetRequiredService<DbContextOptions<ShopContext>>()))
            {
                if (!context.Categories.Any() && !context.Products.Any())
                {
                    context.Categories.AddRange(GetCategories());
                    context.Products.AddRange(GetProducts());
                    context.SaveChanges();
                }
            }
        }

        public static List<DbProduct> GetProducts()
        {
            return new List<DbProduct>()
            {
                new DbProduct
                {
                    Name = "Product1",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1,
                    //ReviewIDs = new List<int> { 1, 2 },
                },
                new DbProduct
                {
                    Name = "Product2",
                    Price = 1000,
                    Stock = 0,
                    AverageRating = 2.5,
                    CategoryID = 2
                },
                new DbProduct
                {
                    Name = "Product3",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1,
                    //ReviewIDs = new List<int> { 1, 2, 3 }
                }/*,
                new DbProduct
                {
                    ID = 4,
                    Name = "Product4",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 3
                },
                new DbProduct
                {
                    ID = 5,
                    Name = "Product5",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 4
                },
                new DbProduct
                {
                    ID = 6,
                    Name = "Product6",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1
                },
                new DbProduct
                {
                    ID = 7,
                    Name = "Product7",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1,
                },
                new DbProduct
                {
                    ID = 8,
                    Name = "Product8",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1
                },
                new DbProduct
                {
                    ID = 9,
                    Name = "Product9",
                    Price = 1000,
                    Stock = 0,
                    AverageRating = 5,
                    CategoryID = 1,
                    //ReviewIDs = new List<int> { 1, 2 }
                },
                new DbProduct
                {
                    ID = 10,
                    Name = "Product10",
                    Price = 1000,
                    Stock = 10,
                    AverageRating = 5,
                    CategoryID = 1
                },*/
            };
        }

        public static List<DbCategory> GetCategories()
        {
            return new List<DbCategory>()
            {
                new DbCategory
                {
                    Name = "Construction toys"
                },
                new DbCategory
                {
                    Name = "Building blocks",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "LEGO",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "F1 LEGO",
                    ParentCategoryID = 3
                }
            };
        }
    }
}
