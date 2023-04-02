using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class CargoDetail : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FirmId { get; set; }
        public bool HasFee { get; set; }
        public double? Price { get; set; }
        public double? ExtraCharge { get; set; }

        [ForeignKey("FirmId")]
        public CargoFirm CargoFirm { get; set; }
    }
}
