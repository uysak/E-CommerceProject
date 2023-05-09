using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public static class EfDbInitializer
    {
        public static void Migrate(ECommerceContext _db)
        {
            _db.Database.Migrate();
        }

        public static void Initialize(ECommerceContext _db)
        {
            AddDefaultCategories(_db);
            AddDefaultCategoryImages(_db);
            AddDefaultOperationClaims(_db);
            AddDefaultRoles(_db);
        }

        private static void AddDefaultOperationClaims(ECommerceContext _db)
        {
            if (_db.OperationClaims.Any())
            {
                return;
            }

            _db.OperationClaims.Add(new OperationClaim
            {
                Name = "AddProduct"
            });

            _db.OperationClaims.Add(new OperationClaim
            {
                Name = "UpdateProduct"
            });

            _db.OperationClaims.Add(new OperationClaim
            {
                Name = "DeleteProduct"
            });

            _db.SaveChanges();

        }

        private static void AddDefaultRoles(ECommerceContext _db)
        {
            if (_db.Roles.Any())
            {
                return;
            }

            _db.Roles.Add(new Role
            {
                Name = "NormalUser"
            });

            _db.Roles.Add(new Role
            {
                Name = "StoreAdmin"
            });

            _db.Roles.Add(new Role
            {
                Name = "StoreModerator"
            });

            _db.Roles.Add(new Role
            {
                Name = "PlatformAdmin"
            });

            _db.SaveChanges();

        }

        private static void AddDefaultCategories(ECommerceContext _db)
        {
            if (_db.Categories.Any())
            {
                return;
            }

            _db.Categories.Add(new Category
            {
                CategoryName = "Elektronik",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Giyim & Moda",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Spor & Fitness",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Araç & Gereç",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Kitap & Dergi",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Güzellik & Kişisel Bakım",
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Mobilya & Ev Eşyaları",
            });

            _db.SaveChanges();

        }

        private static void AddDefaultCategoryImages(ECommerceContext _db)
        {
            if (_db.CategoryImages.Any())
            {
                return;
            }
            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/1/categoryElectronic.jpg",
                CategoryId = 1,
                ObjectKey = "CategoryImages/1/categoryElectronic.jpg"
            });

            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/2/categoryClothingandFashion.jpeg",
                CategoryId = 2,
                ObjectKey = "CategoryImages/2/categoryClothingandFashion.jpeg"
            });

            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/3/categorySportAndFitness.jpg",
                CategoryId = 3,
                ObjectKey = "CategoryImages/3/categorySportAndFitness.jpg"
            });

            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/4/categoryToolsAndEquipment.jpg",
                CategoryId = 4,
                ObjectKey = "CategoryImages/4/categoryToolsAndEquipment.jpg"
            });

            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/5/categoryBookAndMagazine.jpg",
                CategoryId = 5,
                ObjectKey = "CategoryImages/5/categoryBookAndMagazine.jpg"
            });
            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/6/categoryBeautyandPersonalCare.jpg",
                CategoryId = 6,
                ObjectKey = "CategoryImages/6/categoryBeautyandPersonalCare.jpg"
            }); 
            _db.CategoryImages.Add(new CategoryImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/7/categoryFurnitureandHomeAppliances.jpg",
                CategoryId = 7,
                ObjectKey = "CategoryImages/7/categoryFurnitureandHomeAppliances.jpg"
            });

            _db.SaveChanges();
        }

        //public static void AddDefaultAdmin(ECommerceContext _db)
        //{
        //    if (_db.Users.Any())
        //    {
        //        return;
        //    }

        //    _db.Users.Add(new User
        //    {
        //        CreadtedAt = DateTime.Now,
        //        DateOfBirth = DateTime.Now,
        //        Email = "admin@ecommerce.com",
        //        FirstName = "Admin",
        //        LastName = "Admin",
        //    })
        //}

    }
}
