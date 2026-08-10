using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Northwind.DAL;
using Northwind.DAL.Models;

namespace Northwind.BLL
{
    public class OrderDetailService
    {
        public List<OrderDetails> GetByOrderId(int orderId)
        {
            using (var db = new NorthwindContext())
            {
                return db.OrderDetails
                    .Include(od => od.Product)
                    .Where(od => od.OrderID == orderId)
                    .ToList();
            }
        }

        public bool Exists(int orderId, int productId)
        {
            using (var db = new NorthwindContext())
            {
                return db.OrderDetails.Any(od => od.OrderID == orderId && od.ProductID == productId);
            }
        }

        public void Create(OrderDetails detail)
        {
            using (var db = new NorthwindContext())
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
            }
        }

        public void Delete(int orderId, int productId)
        {
            using (var db = new NorthwindContext())
            {
                var detail = db.OrderDetails.Find(orderId, productId);
                if (detail != null)
                {
                    db.OrderDetails.Remove(detail);
                    db.SaveChanges();
                }
            }
        }
    }
}