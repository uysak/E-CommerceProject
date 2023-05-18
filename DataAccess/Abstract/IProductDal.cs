using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Context;
using Entity.Concrete;
using Entity.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        public List<ProductDetailDto> GetProductDetail();
    }
}
