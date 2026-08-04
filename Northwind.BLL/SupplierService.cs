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
    public class SupplierService
    {

        public List<Suppliers> GetAllSuppliers()
        {
            using (var db = new NorthwindContext())
            {
                var suppliers = db.Suppliers.ToList();
                foreach (var s in suppliers)
                {
                    s.CompanyName = s.CompanyName?.Trim();
                }
                return suppliers;
            }
        }

        public List<string> GetDistinctRegions()
        {
            using (var db = new NorthwindContext())
            {
                return db.Suppliers
                    .Where(s => s.Region != null && s.Region != "")
                    .Select(s => s.Region)
                    .Distinct()
                    .OrderBy(r => r)
                    .ToList();
            }
        }

        public Suppliers GetSupplierByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                var supplier = db.Suppliers.FirstOrDefault(c => c.SupplierID == id);
                if (supplier != null)
                {
                    supplier.CompanyName = supplier.CompanyName?.Trim();
                }
                return supplier;
            }
        }

        public void CreateSupplier(Suppliers suppliers)
        {
            suppliers.CompanyName = suppliers.CompanyName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Suppliers.Add(suppliers);
                db.SaveChanges();
            }
        }

        public void UpdateSupplier(Suppliers suppliers)
        {
            suppliers.CompanyName = suppliers.CompanyName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(suppliers).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteSupplier(int id)
        {
            using (var db = new NorthwindContext())
            {
                var supplier = db.Suppliers.Find(id);
                if (supplier != null)
                {
                    db.Suppliers.Remove(supplier);
                    db.SaveChanges();
                }
            }
        }
    }
}
