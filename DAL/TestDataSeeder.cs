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
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(GetCategories());
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetProducts());
                    context.SaveChanges();
                }

                if(!context.Reviews.Any())
                {
                    context.Reviews.AddRange(GetReviews());
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
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    AverageRating = 5,
                    CategoryID = 8
                },
                new DbProduct
                {
                    Name = "Colorful baby book",
                    Price = 1738,
                    Stock = 58,
                    AverageRating = 5,
                    CategoryID = 8
                },
                new DbProduct
                {
                    Name = "Baby telephone",
                    Price = 3725,
                    Stock = 18,
                    AverageRating = 5,
                    CategoryID = 9
                },
                new DbProduct
                {
                    Name = "Fisher Price hammer toy",
                    Price = 8356,
                    Stock = 58,
                    AverageRating = 5,
                    CategoryID = 10
                },
                new DbProduct
                {
                    Name = "Mega Bloks 24 pcs",
                    Price = 4325,
                    Stock = 47,
                    AverageRating = 5,
                    CategoryID = 14
                },
                new DbProduct
                {
                    Name = "Maxi Blocks 56 pcs",
                    Price = 1854,
                    Stock = 36,
                    AverageRating = 5,
                    CategoryID = 14
                },
                new DbProduct
                {
                    Name = "Building Blocks 80 pcs",
                    Price = 4362,
                    Stock = 25,
                    AverageRating = 5,
                    CategoryID = 14
                },
                new DbProduct
                {
                    Name = "Lego City harbour",
                    Price = 27563,
                    Stock = 12,
                    Description = "Description for LEGO City Harbour",
                    AverageRating = 5,
                    CategoryID = 13
                },
                new DbProduct
                {
                    Name = "Lego Duplo Excavator",
                    Price = 6399,
                    Stock = 26,
                    Description = "Description for LEGO Duplo Excavator",
                    AverageRating = 5,
                    CategoryID = 11
                },
                new DbProduct
                {
                    Name = "Child supervision for 1 hour",
                    Price = 800,
                    Stock = 0,
                    Description = "Description",
                    AverageRating = 5,
                    CategoryID = 2
                }
            };
        }

        public static List<DbCategory> GetCategories()
        {
            return new List<DbCategory>()
            {
                new DbCategory
                {
                    Name = "Toy"
                },
                new DbCategory
                {
                    Name = "Play house"
                },
                new DbCategory
                {
                    Name = "Baby toy",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "Construction toy",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "Wooden toy",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "Plush figure",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "Bicycles",
                    ParentCategoryID = 1
                },
                new DbCategory
                {
                    Name = "Months 0-6",
                    ParentCategoryID = 3
                },
                new DbCategory
                {
                    Name = "Months 6-18",
                    ParentCategoryID = 3
                },
                new DbCategory
                {
                    Name = "Months 18-24",
                    ParentCategoryID = 3
                },
                new DbCategory
                {
                    Name = "DUPLO",
                    ParentCategoryID = 4
                },
                new DbCategory
                {
                    Name = "LEGO",
                    ParentCategoryID = 4
                },
                new DbCategory
                {
                    Name = "Building items",
                    ParentCategoryID = 4
                },
                new DbCategory
                {
                    Name = "Building blocks",
                    ParentCategoryID = 5
                },
                new DbCategory
                {
                    Name = "Toys for skill development",
                    ParentCategoryID = 5
                },
                new DbCategory
                {
                    Name = "Logic toys",
                    ParentCategoryID = 5
                },
                new DbCategory
                {
                    Name = "Craftwork toys",
                    ParentCategoryID = 5
                },
                new DbCategory
                {
                    Name = "Baby taxis",
                    ParentCategoryID = 7
                },
                new DbCategory
                {
                    Name = "Motors",
                    ParentCategoryID = 7
                },
                new DbCategory
                {
                    Name = "Tricycle",
                    ParentCategoryID = 7
                }
            };
        }

        public static List<DbReview> GetReviews()
        {
            return new List<DbReview>()
            {

            };
        }
    }
}
