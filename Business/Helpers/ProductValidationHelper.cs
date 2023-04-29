using Business.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class ProductValidationHelper
    {

        IProductService _productService;

        public ProductValidationHelper(IProductService productService)
        {
            _productService = productService;
        }

        public IResult CheckIfProductExists(string productName)
        {
            var result = _productService.GetByProductName(productName);

            if (result.Success)
            {
                return new ErrorResult("Product Already Exist");
            }
            return new SuccessResult("Product Not Exist");
        }

        public IResult CheckIfProductNotExist(int id)
        {
            var result = _productService.GetById(id);

            if (!result.Success)
            {
                return new ErrorResult("Product Not Exist");
            }
            return new SuccessResult("Product Already Exist");
        }
    }
}
