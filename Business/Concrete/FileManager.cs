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

namespace Business.Concrete
{
    public class FileManager : IFileService
    {

        private readonly IConfiguration _config;
        private readonly IStorageService _storageService;
        private ImageValidationHelper _validationHelper;

        public FileManager(IConfiguration config, IStorageService storageService)
        {
            _config = config;
            _storageService = storageService;
            _validationHelper = new ImageValidationHelper(_config);
        }


        public IResult UploadCategoryImage(IFormFile image)
        {
            throw new NotImplementedException();
        }

        public List<S3ResponseDto> UploadProductImages(IFormFileCollection images, int productId)
        {

            List<string> errorList = new List<string>();

            var result = BusinessRules.Run(
                _validationHelper.CheckIfFileExtensionAvailable(images),
                _validationHelper.CheckIfExceedMaxImageCount(images.Count),
                _validationHelper.CheckIfExceedMaxImageSize(images)
                );

            if (!result.Success)
            {
                throw new ArgumentException(result.Message);
            }

            var cred = new AwsCredentials()
            {
                AccessKey = _config["AwsConfiguration:AWSAccessKey"],
                SecretKey = _config["AwsConfiguration:AWSSecretKey"]
            };

            string prefix = "ProductImages/" + productId + "/";

            List<S3ResponseDto> resultList = new List<S3ResponseDto>();

            for (int i = 0; i < images.Count; i++)
            {
                var image = images[i];
                using var memoryStream = new MemoryStream();
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
            }

            return resultList;
        }





    }



}


