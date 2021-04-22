using System;
using System.Data.Entity;
using System.Linq;
using Models.Warehouse;
using Models.User;

namespace Models
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("name=Model1")
        {

        }

        public virtual DbSet<Warehouse.Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Row> Rows { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Rack> Racks { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public virtual DbSet<EmployeePost> EmployeePosts { get; set; }
    }
}