using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryImageManager : ICategoryImageService
    {
        ICategoryImageDal _categoryImageDal;

        public CategoryImageManager(ICategoryImageDal categoryImageDal,IConfiguration conf)
        {
            _categoryImageDal = categoryImageDal;
        }

        public IResult AddImage(CategoryImage categoryImage)
        {
            _categoryImageDal.Add(categoryImage);
            return new SuccessResult();
        }

        public IResult DeleteImage(int categoryId)
        {
            _categoryImageDal.Delete(_categoryImageDal.Get(s => s.CategoryId == categoryId));
            return new SuccessResult();
        }
        public IDataResult<CategoryImage> GetCategoryImage(int categoryId)
        {
            var result = _categoryImageDal.Get(s => s.CategoryId == categoryId);

            if (result == null)
            {
                return new ErrorDataResult<CategoryImage>();
            }

            return new SuccessDataResult<CategoryImage>(result);
        }



    }
}
