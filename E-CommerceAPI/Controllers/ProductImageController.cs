using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Entity.Concrete;
using Entity.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductImageController : Controller
    {

        IProductImageService _productImageService;
        IImageService _imageService;

        public ProductImageController(IProductImageService productImageService, IImageService imageService)
        {
            _productImageService = productImageService;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult GetAllProducts(int productId)
        {
            var result = _productImageService.GetProductImages(productId);
            if (!result.Success)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("UploadProductImage")]
        public async Task<IActionResult> UploadProductImage(IFormFileCollection images, int productId)
        {
            // Process file
            var result = _imageService.UploadProductImage(images, productId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage(string objectKey)
        {
            // Process file
            var result = _imageService.DeleteProductImage(objectKey);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}
