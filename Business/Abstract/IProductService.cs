using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CategoryDTOs;
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
        public IResult CreateProduct(Product product);
        public IResult DeleteProduct(int productId);
        public IResult UpdateProduct(Product product);
        
    }
}
