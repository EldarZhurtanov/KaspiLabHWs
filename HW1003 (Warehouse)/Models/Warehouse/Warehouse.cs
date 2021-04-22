using Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Warehouse
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public WarehouseType Type { get; set; }
        public double Area { get; set; }
        public Address Address { get; set; }
        public ICollection<Row> Rows { get; set; }
        public ICollection<EmployeeProfile> Employees { get; set; }
    }
}
