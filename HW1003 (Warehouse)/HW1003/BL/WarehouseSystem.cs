using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Warehouse;

namespace HW1003.BL
{
    //Конечно мне не нравится то, что здесь я нарушил множество принципов проектирования (как минимум первый принцип солида). 
    //Думаю стоило бы использовать паттерн резориторий, но я не успел бы с ним разобраться из-за малого колтчество свободного времени
    //Я бы никогда не пропустил такой код в продакшн, даже если бы предполагалось, что фунционал не выростет
    class WarehouseSystem
    {
        private readonly WarehouseContext warehouseContext = new WarehouseContext();

        public void AddUnit(Unit unit, int rackiD)
        {
            var rack = warehouseContext.Racks.Find(rackiD);

            if (unit.Product.Measure.Name.ToLower() == "bulk" && rack.Column.Row.Warehouse.Type.Type.ToLower() != "open")
                throw new Exception("Недопустимый склад для сыпучих продуктов");

            rack.Units.Append(unit);

            warehouseContext.SaveChanges();
        }
        public IEnumerable<Unit> FindBySku(string Sku)
        {
            return (from product in warehouseContext.Products
                    where product.Sku == Sku
                    select product.Units).First();
        }
        
        public decimal ValueOfAllGoods()
        {
            return (from product in warehouseContext.Products
                    select product.Units.Sum(unit => unit.Product.Cost * (decimal)unit.Quantity)).Sum();
        }
        public void MoveUnit(Unit unit, Rack newPlace)
        {
            warehouseContext.Units.Find(unit).Rack.Units.Remove(unit);

            warehouseContext.Racks.Find(newPlace).Units.Add(unit);

            warehouseContext.SaveChanges();
        }
    }
}
