using Business.Abstract;
using Business.Services.AWS_S3.Abstract;
using Business.Services.AWS_S3.Entity;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwsS3Controller : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IConfiguration _config;
        private readonly IProductImageService _productImageService;

        private readonly IImageService _imageService;

        public AwsS3Controller(
            IConfiguration config,
            IStorageService storageService,
            IImageService imageService,
            IProductImageService productImageService)
        {
            _config = config;
            _storageService = storageService;
            _imageService = imageService;
            _productImageService = productImageService;
        }

        [HttpPost("UploadProductImage")]
        public async Task<IActionResult> UploadProductImage(IFormFileCollection images, int productId)
        {
            // Process file
            var result = _imageService.UploadProductImage(images, productId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("DeleteProductImage")]
        public async Task<IActionResult> DeleteProductImage(string objectKey)
        {
            // Process file
            var result = _imageService.DeleteProductImage(objectKey);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }



       //[HttpPost("UploadCategoryImage")]
       // public async Task<IActionResult> UploadCategoryImage(IFormFile file, string categoryName)
       // {
       //     // Process file
       //     await using var memoryStream = new MemoryStream();
       //     await file.CopyToAsync(memoryStream);

       //     var fileExt = Path.GetExtension(file.FileName);
       //     var docName = $"{Guid.NewGuid()}{fileExt}";

       //     string prefix = "CategoryImages/" + categoryName + "/";

       //     // call server

       //     var s3Obj = new S3Object()
       //     {
       //         BucketName = "ecommerce-demo1",
       //         InputStream = memoryStream,
       //         Name = docName,
       //         Prefix = prefix
       //     };

       //     var cred = new AwsCredentials()
       //     {
       //         AccessKey = _config["AwsConfiguration:AWSAccessKey"],
       //         SecretKey = _config["AwsConfiguration:AWSSecretKey"]
       //     };

       //     var result = _storageService.UploadFile(s3Obj);
       //     // 
       //     return Ok(result);

       // }

 
    }
}
