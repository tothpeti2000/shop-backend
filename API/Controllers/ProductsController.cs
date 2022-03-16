using AutoMapper;
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

        public ActionResult<List<ProductListItem>> GetProductList()
        {
            return productService.GetProductList();
        }

        [HttpGet("search")]
        public ActionResult<List<ProductListItem>> GetProductsFromQuery([FromQuery] string query)
        {
            return productService.GetProductsByName(query);
        }

        [HttpGet("{ID}")]
        public ActionResult<ProductDetails> GetProductDetails(int ID)
        {
            var productDetails = productService.GetProductDetails(ID);

            if (productDetails == null)
            {
                return NotFound();
            }

            return productDetails;

        }

        [HttpGet("maxprice")]
        public ActionResult<double> GetMaxPrice()
        {
            return productService.GetMaxPrice();
        }
    }
}
