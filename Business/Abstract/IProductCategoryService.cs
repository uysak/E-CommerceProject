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
    public interface IProductCategoryService
    {
        public IResult Create(ProductCategory productCategory);
        public IResult Delete(int productId);
    }
}
