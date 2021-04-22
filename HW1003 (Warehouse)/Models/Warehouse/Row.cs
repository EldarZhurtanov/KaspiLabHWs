using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Row
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Column> Columns { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
