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
            AddDefaultCargoFirms(_db);
            AddDefaultProducts(_db);
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

        public static void AddDefaultCargoFirms(ECommerceContext _db)
        {
            if (_db.CargoFirms.Any()) return;

            _db.CargoFirms.Add(new CargoFirm
            {
                FirmName = "Aras Kargo",
                Img = "https://www.araskargo.com.tr/assets/images/aras-logo.svg",
                SiteUrl = "https://www.araskargo.com.tr"
            });

            _db.CargoFirms.Add(new CargoFirm
            {
                FirmName = "MNG Kargo",
                Img = "https://www.mngkargo.com.tr/assets/sprite/logo.svg",
                SiteUrl = "https://www.araskargo.com.tr"
            });

            _db.SaveChanges();
        }

        public static void AddDefaultProducts(ECommerceContext _db)
        {
            if(_db.Products.Any()) return;


            _db.Products.Add(new Product
            {
                Id = 1,
                CargoFirmId = 1,
                Name = "Iphone 11",
                Price = 12500,
                Quantity = 25,
                Description = "Iphone 11 siyah, 128gb. Apple Türkiye Garantili.",
            });
            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 1,
                CategoryId = 1
            });
            
            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/1/iphone-12-finish-unselect-gallery-2-202207.jpg",
                ProductId = 1,
                ObjectKey = "ProductImages/1/iphone-12-finish-unselect-gallery-2-202207.jpg"
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/1/iphone-12-finish-unselect-gallery-3-202207_GEO_EMEA.jpg",
                ProductId = 1,
                ObjectKey = "ProductImages/1/iphone-12-finish-unselect-gallery-3-202207_GEO_EMEA.jpg"
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/1/iphone-12-finish-unselect-gallery-4-202207.jpg",
                ProductId = 1,
                ObjectKey = "ProductImages/1/iphone-12-finish-unselect-gallery-4-202207.jpg"
            });



            _db.Products.Add(new Product
            {
                Id = 2,
                CargoFirmId = 1,
                Name = "Samsung Galaxy S21",
                Price = 18999,
                Quantity = 80,
                Description = "Samsung Galaxy S21, 128GB, Phantom Black"
            });
            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 2,
                CategoryId = 1
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/2/41puyo%2Bi8bL.jpg",
                ProductId = 2,
                ObjectKey = "ProductImages/2/41puyo%2Bi8bL.jpg"
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/2/indir.jpg",
                ProductId = 2,
                ObjectKey = "ProductImages/2/indir.jpg"
            });


            _db.Products.Add(new Product
            {
                Id = 3,
                CargoFirmId = 2,
                Name = "Sony PlayStation 5",
                Price = 4999,
                Quantity = 50,
                Description = "Sony PlayStation 5 Oyun Konsolu"
            });
            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 3,
                CategoryId = 1
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/3/sony-ps-5.jpg",
                ProductId = 3,
                ObjectKey = "ProductImages/3/sony-ps-5.jpg"
            });

            _db.Products.Add(new Product
            {
                Id = 4,
                CargoFirmId = 2,
                Name = "MacBook Pro",
                Price = 32999,
                Quantity = 30,
                Description = "Apple MacBook Pro, 16 inç, M1 çipi"
            });
            _db.ProductCategories.Add(new ProductCategory
            {
                ProductId = 4,
                CategoryId = 1
            });

            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/4/mbp-spacegray-select-202206_GEO_TR.jpg",
                ProductId = 4,
                ObjectKey = "ProductImages/4/mbp-spacegray-select-202206_GEO_TR.jpg"
            });
            _db.ProductImages.Add(new ProductImage
            {
                ObjectUrl = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/ProductImages/4/mbp13-witb-space-202005.jpg",
                ProductId = 4,
                ObjectKey = "ProductImages/4/mbp13-witb-space-202005.jpg"
            });

            // Diğer ürünlerin oluşturulması...

            _db.SaveChanges();


        }
    }
}
