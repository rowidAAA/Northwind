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
        public List<Orders> GetAll()
        {
            using (var db = new NorthwindContext())
            {
                return db.Orders.Include(o => o.Customer).OrderByDescending(o => o.OrderID).ToList();
            }
        }

        public Orders GetOrderByID(int id)
        {
            using (var db =new NorthwindContext())
            {
                return db.Orders.Include(o=>o.Customer).Include(o => o.OrderDetails.Select(od => od.Product)).FirstOrDefault(o => o.OrderID == id);
            }
        }

        public Orders Create(Orders order)
        {
            using (var db = new NorthwindContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
        }
    }
}
