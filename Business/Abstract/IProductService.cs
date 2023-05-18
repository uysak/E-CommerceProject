using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
using Entity.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public IDataResult<List<Product>> GetAllProducts();
        public IDataResult<Product> GetById(int id);

        public IDataResult<Product> GetByProductName(string productName);

        public IResult CreateProduct(Product product);
        public IResult DeleteProduct(int productId);
        public IResult UpdateProduct(Product product);
        public IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
