﻿using AutoMapper;
using Domain.Models;
using Domain.Models.ProductDTOs;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        public async Task<ActionResult> GetProductList([FromQuery] PagingParams pagingParams)
        {
            var products = await productService.GetProductList(pagingParams.Page, pagingParams.Count);

            return Ok(products);
        }

        [HttpGet("search")]
        public ActionResult<List<ProductListItem>> GetProductsFromQuery([FromQuery] string q)
        {
            return productService.GetProductsByName(q);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetProductDetails(int ID)
        {
            var productDetails = await productService.GetProductDetails(ID);

            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);

        }

        [HttpGet("maxprice")]
        public ActionResult<double> GetMaxPrice()
        {
            return productService.GetMaxPrice();
        }
    }
}
