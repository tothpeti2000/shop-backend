using AutoMapper;
using Domain.Models.ProductDTOs;
using Domain.Models.QueryParams.Paging;
using Domain.Models.QueryParams.SortFilter;
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

        public async Task<ActionResult> GetProductList([FromQuery] PagingParams pagingParams, [FromQuery] SortFilterParams sortFilterParams)
        {
            var response = await productService.GetProductListAsync(pagingParams, null, sortFilterParams);

            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetProductsFromQuery([FromQuery] string q, [FromQuery] PagingParams pagingParams, [FromQuery] SortFilterParams sortFilterParams)
        {
            var response = await productService.GetProductListAsync(pagingParams, q, sortFilterParams);

            return Ok(response);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult> GetProductDetails(int ID)
        {
            var productDetails = await productService.GetProductDetailsAsync(ID);

            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);

        }

        [HttpGet("maxprice")]
        public async Task<ActionResult> GetMaxPrice()
        {
            var maxPrice = await productService.GetMaxPriceAsync();

            return Ok(maxPrice);
        }
    }
}
