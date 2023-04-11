using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Helpers
{
    public class ImageValidationHelper
    {
        private readonly IConfiguration _config;

        int maxImgCount;
        int maxImgSize;
        public ImageValidationHelper(IConfiguration config)
        {
            _config = config;

            maxImgCount = int.Parse(_config["FileUploadOptions:MaxImgCountForProduct"]);
            maxImgSize = int.Parse(_config["FileUploadOptions:MaxImgByteSizeForProduct"]);
        }

        public IResult CheckIfExceedMaxImageCount(int imgCount)
        {
            if (imgCount > maxImgCount)
            {
                return new ErrorResult($"Image count exceeds maximum limit of {maxImgCount}.");
            }
            return new SuccessResult();
        }

        public IResult CheckIfExceedMaxImageSize(IFormFileCollection images)
        {
            foreach (var img in images)
            {
                if (img.Length > maxImgSize)
                {
                    return new ErrorResult($"File size exceeds maximum limit of {maxImgSize / 1024 / 1024}  mb.");
                }
            }
            return new SuccessResult();
        }

        public IResult CheckIfFileExtensionAvailable(IFormFileCollection images)
        {
            foreach (var img in images)
            {
                var extension = Path.GetExtension(img.FileName).ToLower();
                if (extension != ".jpeg" && extension != ".png" && extension != ".jpg")
                {
                    return new ErrorResult("Image must be in JPEG, PNG, or JPG format.");
                }
            }
            return new SuccessResult();
        }
    }
}
