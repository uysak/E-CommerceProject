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

    public class CategoryImageController : Controller
    {
        IImageService _imageService;

        public CategoryImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("UploadProductImage")]
        public async Task<IActionResult> UploadCategoryImage(IFormFile image, int categoryId)
        {
            // Process file
            var result = _imageService.UploadCategoryImage(image, categoryId);
            
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
            var result = _imageService.DeleteCategoryImage(objectKey);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


    }
}
