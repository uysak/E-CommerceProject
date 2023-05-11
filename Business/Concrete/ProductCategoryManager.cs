using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryDal _productCategoryDal;

        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public IResult Create(ProductCategory productCategory)
        {
            _productCategoryDal.Add(productCategory);
            return new SuccessResult();
        }

        public IResult Delete(int productId)
        {
            _productCategoryDal.Delete(_productCategoryDal.Get(s=>s.Id == productId));
            return new SuccessResult();
        }
    }
}
