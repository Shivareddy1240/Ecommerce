using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using ProductsService.Service;

namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var addedProduct = _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProducts), new { id = addedProduct.Id}, addedProduct);
        }
    }
}
