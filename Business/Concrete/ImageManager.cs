using Amazon.S3.Model;
using Business.Abstract;
using Business.Helpers;
using Business.Services.AWS_S3.Abstract;
using Business.Services.AWS_S3.Entity;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using IResult = Core.Utilities.Results.IResult;
using S3Object = Business.Services.AWS_S3.Entity.S3Object;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IProductImageService _productImageService;
        private readonly ICategoryImageService _categoryImageService;

        private readonly IConfiguration _config;
        private readonly IStorageService _storageService;
        private readonly ImageValidationHelper _imageValidationHelper;
        private readonly ProductImageValidationHelper _productImageValidationHelper;

        public ImageManager(IConfiguration config, IStorageService storageService, IProductImageService productImageService, ICategoryImageService categoryImageService)
        {
            _config = config;
            _storageService = storageService;
            _productImageService = productImageService;
            _categoryImageService = categoryImageService;

            _imageValidationHelper = new ImageValidationHelper(_config);
            _productImageValidationHelper = new ProductImageValidationHelper(_config, _productImageService);
        }


        public IResult UploadProductImage(IFormFileCollection images, int productId)
        {
            var result = BusinessRules.Run(
                _imageValidationHelper.CheckIfFileExtensionAvailable(images),
                _imageValidationHelper.CheckIfExceedMaxImageCount(images.Count),
                _imageValidationHelper.CheckIfExceedMaxImageSize(images),
                _productImageValidationHelper.CheckIfProductImageLimitExceeded(productId)
            );

            if (!result.Success)
            {
                throw new ArgumentException(result.Message);
            }

            List<S3ResponseDto> resultList = new List<S3ResponseDto>();

            for (int i = 0; i < images.Count; i++)
            {
                var check = BusinessRules.Run(_productImageValidationHelper.CheckIfProductImageLimitExceeded(productId));
                if (!check.Success)
                {
                    return new ErrorResult(check.Message);
                }
                var image = images[i];
                var memoryStream = new MemoryStream();
                try
                {
                    image.CopyTo(memoryStream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

                var fileExt = Path.GetExtension(image.FileName);
                var docName = $"{Guid.NewGuid()}{fileExt}";
                var prefix = "ProductImages/" + productId + "/";

                var s3Obj = new S3Object()
                {
                    BucketName = "ecommerce-demo1",
                    InputStream = memoryStream,
                    Name = docName,
                    Prefix = prefix
                };

                var uploadResult = _storageService.UploadFile(s3Obj);

                if (uploadResult.StatusCode != 201)
                {
                    throw new Exception($"Failed to upload image: {uploadResult.Message}");
                }

                resultList.Add(uploadResult);

                _productImageService.AddImage(new ProductImage
                {
                    ProductId = productId,
                    ObjectUrl = uploadResult.ObjectUrl,
                    ObjectKey = prefix + docName
                });

            }
            return new SuccessDataResult<List<S3ResponseDto>>(resultList);
        }

        public IResult DeleteProductImage(string objectKey)
        {
            var result = _storageService.DeleteFile(objectKey).Result;

            if (!result.Success)
            {
                return new ErrorResult();
            }
            result = _productImageService.DeleteImage(objectKey);

            if (!result.Success)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult UploadCategoryImage(IFormFile image, int categoryId)
        {

            var memoryStream = new MemoryStream();
            try
            {
                image.CopyTo(memoryStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            var fileExt = Path.GetExtension(image.FileName);
            var docName = $"{Guid.NewGuid()}{fileExt}";
            var prefix = "CategoryImages/" + categoryId + "/";

            var s3Obj = new S3Object()
            {
                BucketName = "ecommerce-demo1",
                InputStream = memoryStream,
                Name = docName,
                Prefix = prefix
            };

            var uploadResult = _storageService.UploadFile(s3Obj);

            if (uploadResult.StatusCode != 201)
            {
                throw new Exception($"Failed to upload image: {uploadResult.Message}");
            }
            _categoryImageService.AddImage(new CategoryImage
            {
                CategoryId = categoryId,
                ObjectUrl = uploadResult.ObjectUrl,
                ObjectKey = prefix + docName
            });


            return new SuccessDataResult<S3ResponseDto>(uploadResult);
        }

        public IResult DeleteCategoryImage(string objectKey)
        {
            var result = _storageService.DeleteFile(objectKey).Result;

            if (!result.Success)
            {
                return new ErrorResult();
            }
            result = _categoryImageService.DeleteImage(objectKey);

            if (!result.Success)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}


