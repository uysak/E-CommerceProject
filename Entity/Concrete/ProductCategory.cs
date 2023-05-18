using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ProductCategory : IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
