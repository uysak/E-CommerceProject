using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            var result = _categoryDal.GetAll();
            if(result == null || result.Count == 0)
            {
                return new ErrorDataResult<List<Category>>("Veri yok");
            }
            return new SuccessDataResult<List<Category>>(result);
        }

        public IResult CreateCategory(Category category)
        {
            var result = BusinessRules.Run(CheckIfCategoryExists(category.CategoryName));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult DeleteCategory(int id)
        {
            var result = BusinessRules.Run(CheckIfCategoryNotExist(id));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            var deletedCategory = _categoryDal.Get(s => s.Id == id);

            _categoryDal.Delete(deletedCategory);
            return new SuccessResult();
        }
        public IResult UpdateCategory(Category category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNotExist(category.Id));

            var updatedCategory = _categoryDal.Get(s => s.Id == category.Id);

            updatedCategory.CategoryImg = category.CategoryImg == default ? updatedCategory.CategoryImg : category.CategoryImg;
            updatedCategory.CategoryName = category.CategoryName == default ? updatedCategory.CategoryName : category.CategoryName;

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _categoryDal.Update(updatedCategory);
            return new SuccessResult();
        }

        public IResult CheckIfCategoryExists(string categoryName)
        {
            var result = _categoryDal.Get(s => s.CategoryName == categoryName);

            if(result != null)
            {
                return new ErrorResult("Category Already Exist");
            }
            return new SuccessResult("Category Not Exist");
        }

        public IResult CheckIfCategoryNotExist(int id)
        {
            var result = _categoryDal.Get(s => s.Id == id);

            if (result == null)
            {
                return new ErrorResult("Category Not Exist");
            }
            return new SuccessResult("Category Already Exist");
        }

    }
}
