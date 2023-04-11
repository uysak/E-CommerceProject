using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.CargoFirmDTOs
{
    public class CargoFirmForCreateDto
    {
        public string FirmName { get; set; }
        public string SiteUrl { get; set; }
        public string Img { get; set; }
    }
}
