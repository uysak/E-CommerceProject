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
        IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult CreateCategory(CategoryForCreateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            var result = _categoryService.CreateCategory(category);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


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

