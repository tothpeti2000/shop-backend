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
        private readonly IMapper mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public ActionResult<List<Product>> GetAllProducts()
        {
            return repository.GetAllProducts();
        }

        [HttpGet("{ID}")]
        public ActionResult<ProductDetails> GetProductDetails(int ID)
        {
            var product = repository.GetByID(ID);
            var productDetails = mapper.Map<Product, ProductDetails>(product);

            return productDetails;

        }

        [HttpGet("maxprice")]
        public ActionResult<double> GetMaxPrice()
        {
            return repository.GetMaxPrice();
        }
    }
}
