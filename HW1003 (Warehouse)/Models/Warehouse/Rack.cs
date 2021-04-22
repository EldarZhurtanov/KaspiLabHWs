using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Rack
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Unit> Units { get; set; }
        public Column Column { get; set; }
    }
}
