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
    public class Product : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double ProductRate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public int CargoDetailId { get; set; }
        public int CategoryId { get; set; }
        

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("CargoDetailId")]
        public CargoDetail CargoDetail { get; set; }
    }

}
