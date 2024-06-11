using Lightening.Ecommerce.Application.DTOs;
using Lightening.Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lightening.Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productsService)
        {
            _productService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQueryRequest request)
        {
            var result = await _productService.GetProductSummaryListAsync(request);
            return Ok(result);
        }

        [HttpGet("{productModelId}")]
        public async Task<IActionResult> GetProductModelDetailsAsync(int productModelId)
        {
            var product = await _productService.GetProductDetailsAsync(productModelId);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var result = await _productService.GetAllProductCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("thumbnail/{photoId}")]
        public async Task<IActionResult> GetProductThumbnailAsync(int photoId)
        {
            var result = await _productService.GetProductThumbnailAsync(photoId);
            if (result == null) return NotFound();
            return File(result, "image/gif");
        }

        [HttpGet("largePhoto/{photoId}")]
        public async Task<IActionResult> GetProductLargePhotoAsync(int photoId)
        {
            var result = await _productService.GetProductLargePhotoAsync(photoId);
            if (result == null) return NotFound();
            return File(result, "image/gif");
        }
    }
}
