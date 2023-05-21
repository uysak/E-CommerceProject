using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ProductValidationHelper _validationHelper;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            _validationHelper = new ProductValidationHelper(this);
        }
        
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetail(s => s.Category.Any(s => s.Id == 1));
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }


        public IDataResult<List<Product>> GetAllProducts()
        {
            var result = _productDal.GetAll();
            if(result == null || result.Count == 0)
            {
                return new ErrorDataResult<List<Product>>("Veri yok");
            }
            return new SuccessDataResult<List<Product>>(result);
        }
        public IDataResult<Product> GetById(int id)
        {
            var result = _productDal.Get(s=>s.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Veri yok");
            }
            return new SuccessDataResult<Product>(result);
        }
        public IDataResult<Product> GetByProductName(string productName)
        {
            var result = _productDal.Get(s => s.Name == productName);
            if (result == null)
            {
                return new ErrorDataResult<Product>("Veri yok");
            }
            return new SuccessDataResult<Product>(result);
        }

        public IResult CreateProduct(Product product)
        {
            var result = BusinessRules.Run(_validationHelper.CheckIfProductExists(product.Name));

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult DeleteProduct(int id)
        {
            var result = BusinessRules.Run(_validationHelper.CheckIfProductNotExist(id));

            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var deletedProduct = _productDal.Get(s => s.Id == id);

            _productDal.Delete(deletedProduct);
            return new SuccessResult();
        }
        public IResult UpdateProduct(Product product)
        {
            var result = BusinessRules.Run(_validationHelper.CheckIfProductNotExist(product.Id));

            var updatedProduct = _productDal.Get(s => s.Id == product.Id);
            
            updatedProduct.Description = product.Description == default ? updatedProduct.Description : product.Description;

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _productDal.Update(updatedProduct);
            return new SuccessResult();
        }

    }
}
