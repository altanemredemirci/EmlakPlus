using EmlakPlus.API.Repositories.ProductRepository;
using EmlakPlus.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var values = await _productRepository.GetByIdAsync(id);

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDetail entity)
        {
            var result = await _productRepository.CreateProductAsync(entity);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDetail entity)
        {
            var result = await _productRepository.UpdateProductAsync(entity);
            if (result == 0)
            {
                return StatusCode(500, "A problem happend while handling your request");
            }

            return NoContent();
        }
    }
}
