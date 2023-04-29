using Business.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class CategoryValidationHelper
    {
        ICategoryService _categoryService;

        public CategoryValidationHelper(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IResult CheckIfCategoryExists(string categoryName)
        {
            var result = _categoryService.GetByCategoryName(categoryName);

            if (result.Success)
            {
                return new ErrorResult("Category Already Exist");
            }
            return new SuccessResult("Category Not Exist");
        }

        public IResult CheckIfCategoryNotExist(int id)
        {
            var result = _categoryService.GetById(id);

            if (!result.Success)
            {
                return new ErrorResult("Category Not Exist");
            }
            return new SuccessResult("Category Already Exist");
        }
    }
}
