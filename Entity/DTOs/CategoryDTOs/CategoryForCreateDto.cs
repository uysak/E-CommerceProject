using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CategoryDTOs
{

    public class CategoryForCreateDto : IDto
    {
        public string? CategoryName { get; set; }
        public string? CategoryImg { get; set; }
    }

}
