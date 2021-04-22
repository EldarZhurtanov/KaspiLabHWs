using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Rack> Racks { get; set; }
        public Row Row { get; set; }
    }
}
