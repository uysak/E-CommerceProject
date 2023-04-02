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
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/Electronic/categoryElectronic.jpg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Giyim & Moda",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/ClothingAndFashion/categoryClothingandFashion.jpeg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Spor & Fitness",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/SportAndFitness/categorySportAndFitness.jpg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Araç & Gereç",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/ToolsAndEquipment/categoryToolsAndEquipment.jpg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Kitap & Dergi",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/BookAndMagazine/categoryBookAndMagazine.jpg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Güzellik & Kişisel Bakım",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/BeautyAndPersonalCare/categoryBeautyandPersonalCare.jpg"
            });

            _db.Categories.Add(new Category
            {
                CategoryName = "Mobilya & Ev Eşyaları",
                CategoryImg = "https://ecommerce-demo1.s3.eu-central-1.amazonaws.com/CategoryImages/FurnitureandHomeAppliance/categoryFurnitureandHomeAppliances.jpg"
            });

            _db.SaveChangesAsync();

        }

    }
}
