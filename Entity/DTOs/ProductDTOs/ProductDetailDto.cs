using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.ProductDTOs
{
    public class ProductDetailDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CargoFirm CargoFirm { get; set; }
        public List<Category> Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
