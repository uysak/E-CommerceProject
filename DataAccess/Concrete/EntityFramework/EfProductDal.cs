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
        public List<ProductDetailDto> GetProductDetail(Func<ProductDetailDto, bool> filter = null)
        {
            using (var context = new ECommerceContext())
            {
                var query = from product in context.Products
                            join cargoFirm in context.CargoFirms on product.CargoFirmId equals cargoFirm.Id
                            join productImage in context.ProductImages on product.Id equals productImage.ProductId into productImagesGroup
                            join pc in context.ProductCategories on product.Id equals pc.ProductId into categoriesGroup
                            from category in categoriesGroup.DefaultIfEmpty()
                            select new ProductDetailDto
                            {
                                CargoFirm = cargoFirm,
                                Description = product.Description,
                                Price = product.Price,
                                ProductImages = productImagesGroup.ToList(),
                                ProductName = product.Name,
                                Quantity = product.Quantity,
                                Category = category != null ? new List<Category>
                        {
                            new Category
                            {
                                Id = category.Category.Id,
                                CategoryName = category.Category.CategoryName,
                                CategoryImage = category.Category.CategoryImage
                            }
                        } : null
                            };

                var result = filter != null ? query.ToList().Where(filter).ToList() : query.ToList();
                return result;
            }
        }

    }
}
