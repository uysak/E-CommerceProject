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
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IConfiguration _conf;
        ProductImageValidationHelper _validationHelper;

        public ProductImageManager(IProductImageDal productImageDal,IConfiguration conf)
        {
            _productImageDal = productImageDal;
            _conf = conf;
        }

        public IResult AddImage(ProductImage productImage)
        {
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IResult DeleteImage(string objectKey)
        {
            _productImageDal.Delete(_productImageDal.Get(s => s.ObjectKey == objectKey));
            return new SuccessResult();
        }
        public IDataResult<List<ProductImage>> GetProductImages(int productId)
        {
            var result = _productImageDal.GetAll(s => s.ProductId == productId);

            if (result.IsNullOrEmpty())
            {
                return new ErrorDataResult<List<ProductImage>>();
            }

            return new SuccessDataResult<List<ProductImage>>(result);
        }



    }
}
