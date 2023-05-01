using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ECommerceContext>, ICategoryDal
    {
        public List<Category> GetCategoryDetail()
        {
            using(var context = new ECommerceContext())
            {
                var categoryDetails = context.Categories.Include(s => s.CategoryImage).ToList();
                return categoryDetails;
            }
        }
    }
}
