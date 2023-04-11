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
        AwsS3Controller _awsS3Controller;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
        public IActionResult CreateProduct(ProductForCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.Now;

            var result = _productService.CreateProduct(product);

            if (!result.Success)
            {
                return NotFound();
            }

            return Ok(result);

        }


    }
}
