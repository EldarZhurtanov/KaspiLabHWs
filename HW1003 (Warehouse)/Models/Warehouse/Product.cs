using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public Measure Measure { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
