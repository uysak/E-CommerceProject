using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductCountOfCategoryError = "Kategorideki ürün sayısını aştınız.";
        public static string ProductNameAlreadyExists = "Bu isme sahip bir ürün zaten mevcut.";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserAlreadyExists = "Bu mail adresi ile kullanıcı zaten mevcut.";
        public static string UserRegistered { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
    }
}
