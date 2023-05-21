using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IImageService _imageService;
        IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IImageService imageService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            if (!categories.Success)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [Authorize(Roles = "StoreModerator")]
        [HttpPost]
        public IActionResult CreateCategory(IFormFile image, [FromForm]CategoryForCreateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            var result = _categoryService.CreateCategory(category);

            if (!result.Success) return BadRequest(result);

            var createdCategory = _categoryService.GetByCategoryName(categoryDto.CategoryName);

            if (!createdCategory.Success) return BadRequest(createdCategory.Message);
            var uploadImage = _imageService.UploadCategoryImage(image, createdCategory.Data.Id);

            if (!uploadImage.Success) return BadRequest(uploadImage.Message);

            return Ok(result);
        }

        [Authorize(Roles = "StoreModerator")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var deleteImage = _imageService.DeleteCategoryImage(id);
            if (!deleteImage.Success) return BadRequest(deleteImage);
            var result = _categoryService.DeleteCategory(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateCategory(int categoryId, CategoryForUpdateDto categoryDto)
        {

            var category = _mapper.Map<Category>(categoryDto);
            category.Id = categoryId;

            var result = _categoryService.UpdateCategory(categoryId,category);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }

}

