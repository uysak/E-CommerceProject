using Business.Abstract;
using Business.Services.AWS_S3.Abstract;
using Business.Services.AWS_S3.Entity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwsS3Controller : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IFileService _fileService;

        public AwsS3Controller(
            ILogger<WeatherForecastController> logger,
            IConfiguration config,
            IStorageService storageService,
            IFileService fileService)
        {
            _logger = logger;
            _config = config;
            _storageService = storageService;
            _fileService = fileService;
        }

        [HttpPost("UploadProductImage")]
        public async Task<IActionResult> UploadProductImage(IFormFileCollection images,int productId)
        {
            // Process file
            var result = _fileService.UploadProductImages(images, productId);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }


        [HttpPost("UploadCategoryImage")]
        public async Task<IActionResult> UploadCategoryImage(IFormFile file, string categoryName)
        {
            // Process file
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(file.FileName);
            var docName = $"{Guid.NewGuid()}{fileExt}";

            string prefix = "CategoryImages/" + categoryName + "/";

            // call server

            var s3Obj = new S3Object()
            {
                BucketName = "ecommerce-demo1",
                InputStream = memoryStream,
                Name = docName,
                Prefix = prefix
            };

            var cred = new AwsCredentials()
            {
                AccessKey = _config["AwsConfiguration:AWSAccessKey"],
                SecretKey = _config["AwsConfiguration:AWSSecretKey"]
            };

            var result = _storageService.UploadFile(s3Obj);
            // 
            return Ok(result);

        }


    }
}
