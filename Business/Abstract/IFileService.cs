using Business.Services.AWS_S3.Entity;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IFileService
    {
        public List<S3ResponseDto> UploadProductImages(IFormFileCollection images, int productId);
        public IResult UploadCategoryImage(IFormFile image);

    }
}
