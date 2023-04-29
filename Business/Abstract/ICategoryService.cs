using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IDataResult<List<Category>> GetAllCategories();
        public IDataResult<Category> GetById(int id);
        public IDataResult<Category> GetByCategoryName(string categoryName);
        public IResult CreateCategory(Category category);
        public IResult DeleteCategory(int id);
        public IResult UpdateCategory(int id, Category category);

    }
}
