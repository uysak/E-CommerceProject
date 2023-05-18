using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Entity.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,ECommerceContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetail()
        {
            using(var context = new ECommerceContext())
            {
                var result = (from product in context.Products
                             join cargoFirm in context.CargoFirms on product.CargoFirmId equals cargoFirm.Id
                             join productImage in context.ProductImages on product.Id equals productImage.ProductId into productImagesGroup
                             select new ProductDetailDto
                             {
                                 CargoFirm = cargoFirm,
                                 Description = product.Description,
                                 Price = product.Price,
                                 ProductImages = productImagesGroup.ToList(),
                                 ProductName = product.Name,
                                 Quantity = product.Quantity,
                                 Category = (from pc in context.ProductCategories
                                                 join c in context.Categories on pc.CategoryId equals c.Id
                                                 where pc.ProductId == product.Id
                                                 select new Category
                                                 {
                                                     CategoryName = c.CategoryName,
                                                     CategoryImage = c.CategoryImage
                                                 }).ToList()
                             }).ToList();
                return result;
            }
            return null;
        }
    }
}
