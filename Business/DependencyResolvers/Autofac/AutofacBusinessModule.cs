using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Services.AWS_S3.Abstract;
using Business.Services.AWS_S3.Concrete.AwsS3.Services;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<EfCargoFirmDal>().As<ICargoFirmDal>().SingleInstance();
            builder.RegisterType<CargoFirmManager>().As<ICargoFirmService>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();

            builder.RegisterType<CategoryImageManager>().As<ICategoryImageService>().SingleInstance();
            builder.RegisterType<EfCategoryImageDal>().As<ICategoryImageDal>().SingleInstance();


            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
            builder.RegisterType<StorageService>().As<IStorageService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


        }
    }
}
