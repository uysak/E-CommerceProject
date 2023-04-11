using Business.Abstract;
using Core.Utilities.Business;
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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
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

        public IResult CreateProduct(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductExists(product.Name));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult DeleteProduct(int id)
        {
            var result = BusinessRules.Run(CheckIfProductNotExist(id));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            var deletedProduct = _productDal.Get(s => s.Id == id);

            _productDal.Delete(deletedProduct);
            return new SuccessResult();
        }
        public IResult UpdateProduct(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNotExist(product.Id));

            var updatedProduct = _productDal.Get(s => s.Id == product.Id);
            
            updatedProduct.Description = product.Description == default ? updatedProduct.Description : product.Description;

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _productDal.Update(updatedProduct);
            return new SuccessResult();
        }

        public IResult CheckIfProductExists(string productName)
        {
            var result = _productDal.Get(s => s.Name == productName);

            if(result != null)
            {
                return new ErrorResult("Product Already Exist");
            }
            return new SuccessResult("Product Not Exist");
        }

        public IResult CheckIfProductNotExist(int id)
        {
            var result = _productDal.Get(s => s.Id == id);

            if (result == null)
            {
                return new ErrorResult("Product Not Exist");
            }
            return new SuccessResult("Product Already Exist");
        }

    }
}
