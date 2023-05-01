using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Context;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        public List<Category> GetCategoryDetail();
    }
}
