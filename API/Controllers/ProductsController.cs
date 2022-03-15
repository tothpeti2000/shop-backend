﻿using AutoMapper;
using Domain.Models.ProductDTOs;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult<List<Product>> GetAllProducts()
        {
            return repository.GetAllProducts();
        }

        [HttpGet("{ID}")]
        public ActionResult<ProductDetails> GetProductDetails(int ID)
        {
            var productDetails = repository.GetProductDetails(ID);

            if (productDetails == null)
            {
                return NotFound();
            }

            return productDetails;

        }

        [HttpGet("maxprice")]
        public ActionResult<double> GetMaxPrice()
        {
            return repository.GetMaxPrice();
        }
    }
}
