using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        ICategoryImageService _categoryImageService;
        IImageService _imageService;
        CategoryValidationHelper _validationHelper;

        public CategoryManager(ICategoryDal categoryDal, IImageService imageService, ICategoryImageService categoryImageService)
        {
            _categoryDal = categoryDal;
            _validationHelper = new CategoryValidationHelper(this);
            _imageService = imageService;
            _categoryImageService = categoryImageService;
        }

        public IDataResult<List<CategoryDetailDto>> GetAllCategories()
        {
            var categories = _categoryDal.GetCategoryDetail();

            var details = categories.Select(s =>
                new CategoryDetailDto
                {
                    Id = s.Id,
                    CategoryName = s.CategoryName,
                    CategoryImage = s.CategoryImage.ObjectUrl
                }).ToList();


            if(categories == null || categories.Count == 0)
            {
                return new ErrorDataResult<List<CategoryDetailDto>>("Veri yok");
            }
            return new SuccessDataResult<List<CategoryDetailDto>>(details);
        }

        public IDataResult<Category> GetByCategoryName(string categoryName)
        {
            var result = _categoryDal.Get(s=>s.CategoryName == categoryName);
            if (result == null)
            {
                return new ErrorDataResult<Category>("Veri yok");
            }
            return new SuccessDataResult<Category>(result);
        }
        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(s => s.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Category>("Veri yok");
            }
            return new SuccessDataResult<Category>(result);
        }

        public IResult CreateCategory(Category category)
        {

            var result = BusinessRules.Run(_validationHelper.CheckIfCategoryExists(category.CategoryName));

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            
            _categoryDal.Add(category);
            return new SuccessResult();
        }
        public IResult DeleteCategory(int id)
        {
            var result = BusinessRules.Run(_validationHelper.CheckIfCategoryNotExist(id));

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var deletedCategory = _categoryDal.Get(s => s.Id == id);

            _categoryDal.Delete(deletedCategory);
            return new SuccessResult();
        }
        public IResult UpdateCategory(int id, Category category)
        {
            var result = BusinessRules.Run(_validationHelper.CheckIfCategoryNotExist(id));

            var updatedCategory = _categoryDal.Get(s => s.Id == id);

            updatedCategory.CategoryName = category.CategoryName == default ? updatedCategory.CategoryName : category.CategoryName;


            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _categoryDal.Update(updatedCategory);
            return new SuccessResult();
        }
    }
}
