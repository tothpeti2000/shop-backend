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
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
                },
                new DbProduct
                {
                    Name = "Activity playgim",
                    Price = 7488,
                    Stock = 21,
                    Description = "",
                    AverageRating = 5,
                    ImgURL = "",
                    CategoryID = 1
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
