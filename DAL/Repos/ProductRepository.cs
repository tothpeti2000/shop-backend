using AutoMapper.QueryableExtensions;
using DAL.DbObjects;
using DAL.Profiles;
using Domain.Mapping.Profiles;
using Domain.Models;
using Domain.Models.QueryParams.Paging;
using Domain.Models.ProductDTOs;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.QueryParams.SortFilter;

namespace DAL.Repos
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext db;
        private readonly Mapper<DbProductProfile> mapper;

        public ProductRepository(ShopContext db) 
        {
            this.db = db;
            mapper = new Mapper<DbProductProfile>();
        }

        public async Task<PagedResponse<ProductListItem>> GetProductsPagedAsync(PagingParams pagingParams, string? query, SortFilterParams sortFilterParams)
        {
            var queryMatches = GetQueryMatches(query);
            // TODO: Add filtering
            var filtered = queryMatches;
            var sorted = Sort(filtered, sortFilterParams.Sort);

            var dbProducts = await sorted
                .Skip((pagingParams.Page - 1) * pagingParams.Count)
                .Take(pagingParams.Count)
                .ToArrayAsync();

            var totalProducts = sorted.Count();

            var pagedProducts = mapper.Map<DbProduct[], ProductListItem[]>(dbProducts);

            return new PagedResponse<ProductListItem>
            {
                Items = pagedProducts,
                CurrentPage = pagingParams.Page,
                TotalPages = (int)Math.Ceiling((double)totalProducts / pagingParams.Count),
                TotalItems = totalProducts
            };
        }

        public async Task<ProductDetails?> GetDetailsByIDAsync(int ID)
        {
            var dbProduct = await db.Products
                .FirstOrDefaultAsync(p => p.ID == ID);

            return mapper.Map<DbProduct, ProductDetails>(dbProduct);
        }

        public async Task<double> GetMaxPriceAsync()
        {
            return await db.Products
                .MaxAsync(p => p.Price);
        }

        private IQueryable<DbProduct> GetQueryMatches(string? query)
        {
            return db.Products
                .Where(p => query == null || p.Name.ToUpper().Contains(query.ToUpper()));
        }

        private IQueryable<DbProduct> Sort(IQueryable<DbProduct> products, string mode)
        {
            if (mode == "nameAZ")
            {
                return products
                .OrderBy(p => p.Name);
            }

            if (mode == "nameZA")
            {
                return products
                .OrderByDescending(p => p.Name);
            }

            if (mode == "priceLTH")
            {
                return products
                .OrderBy(p => p.Price);
            }

            if (mode == "priceHTL")
            {
                return products
                .OrderByDescending(p => p.Price);
            }

            return products
                .OrderBy(p => p.ID);
        }
    }
}
