using Northwind.DAL.Models;
using Northwind.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Northwind.BLL
{
    public class OrderService
    {
        public List<Order> GetAll()
        {
            using (var db = new NorthwindContext())
            {
                return db.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderDetails)
                    .OrderByDescending(o => o.OrderID).ToList();
            }
        }

        public Order GetOrderByID(int id)
        {
            using (var db =new NorthwindContext())
            {
                return db.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Employee)
                    .Include(o => o.Shipper)
                    .Include(o => o.OrderDetails.Select(od => od.Product))
                    .FirstOrDefault(o => o.OrderID == id);
            }
        }

        public void Delete(int id)
        {
            using (var db = new NorthwindContext())
            {
                var order = db.Orders.Find(id);
                if (order == null) return;

                db.OrderDetails.RemoveRange(db.OrderDetails.Where(od => od.OrderID == id));
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public Order Create(Order order)
        {
            order.CustomerID = order.CustomerID?.Trim();
            order.ShipName = order.ShipName?.Trim();
            order.ShipAddress = order.ShipAddress?.Trim();
            order.ShipCity = order.ShipCity?.Trim();
            order.ShipRegion = order.ShipRegion?.Trim();
            order.ShipPostalCode = order.ShipPostalCode?.Trim();
            order.ShipCountry = order.ShipCountry?.Trim();

            using (var db = new NorthwindContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }
    }
}
