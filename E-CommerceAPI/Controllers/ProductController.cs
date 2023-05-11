using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        IMapper _mapper;
        IProductService _productService;
        IImageService _imageService;
        AwsS3Controller _awsS3Controller;

        public ProductController(IProductService productService,IMapper mapper, IImageService imageService)
        {
            _productService = productService;
            _mapper = mapper;
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (!result.Success)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromForm]ProductForCreateDto productDto,IFormFileCollection images)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.Now;

            var result = _productService.CreateProduct(product);

            if (!result.Success) return BadRequest(result);
            
            var createdProduct = _productService.GetByProductName(product.Name);
            if (!result.Success) return BadRequest(createdProduct);

            var uploadImage = _imageService.UploadProductImage(images, createdProduct.Data.Id);
            if (!result.Success) return BadRequest(uploadImage);

            return Ok(result);

        }


    }
}
