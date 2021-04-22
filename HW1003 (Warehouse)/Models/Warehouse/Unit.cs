using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Sku { get; set; }
        [Required, Range(0.0001, double.MaxValue)]
        public double Quantity { get; set; }

        public Product Product { get; set; }
        public Rack Rack { get; set; }
    }
}
