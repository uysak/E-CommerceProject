using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class ProductImageValidationHelper
    {
        IConfiguration _conf;
        IProductImageService _productImageService;
        public ProductImageValidationHelper(IConfiguration conf, IProductImageService productImageService)
        {
            _conf = conf;
            _productImageService = productImageService;
        }

        
        public IResult CheckIfProductImageLimitExceeded(int productId)
        {
            var maxLimit = int.Parse(_conf["FileUploadOptions:MaxImgCountForProduct"]);
            var productImages = _productImageService.GetProductImages(productId).Data;

            if (productImages != null && productImages.Count >= maxLimit)
            {
                return new ErrorResult("Max limit of image count is exceeded");
            }

            return new SuccessResult();
        }

        public IResult CheckIfProductImageExists(int productId)
        {
            var productImages = _productImageService.GetProductImages(productId).Data;

            if (productImages.Count == 0 || productImages == null)
            {
                return new ErrorResult("Images are not found");
            }
            return new SuccessResult();
        }

    }
}
