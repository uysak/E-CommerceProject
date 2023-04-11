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
    public interface ICategoryService
    {
        public IDataResult<List<Category>> GetAllCategories();
        public IResult CreateCategory(Category category);
        public IResult DeleteCategory(int id);
        public IResult UpdateCategory(Category category);

    }
}
