using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class ShipperService
    {
        public List<Shippers> GetAllShippers()
        {
            using (var db = new NorthwindContext())
            {
                return db.Shippers.OrderBy(s => s.CompanyName).ToList();
            }
        }

        public Shippers GetShipperByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                return db.Shippers.FirstOrDefault(s => s.ShipperID == id);
            }
        }

        public void CreateShipper(Shippers shipper)
        {
            shipper.CompanyName = shipper.CompanyName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
            }
        }

        public void UpdateShipper(Shippers shipper)
        {
            shipper.CompanyName = shipper.CompanyName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(shipper).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteShipper(int id)
        {
            using (var db = new NorthwindContext())
            {
                var shipper = db.Shippers.Find(id);
                if (shipper != null)
                {
                    db.Shippers.Remove(shipper);
                    db.SaveChanges();
                }
            }
        }
    }
}
