using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryImageService
    {
        public IResult AddImage(CategoryImage categoryImage);
        public IResult DeleteImage(string objectKey);
        public IDataResult<CategoryImage> GetCategoryImage(int categoryId);
    }
}
