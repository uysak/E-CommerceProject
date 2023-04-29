using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CategoryDTOs
{
        public class CategoryForUpdateDto : IDto
        {
            public string? CategoryName { get; set; }
            public IFormFile? CategoryImage { get; set; }
        }
}
