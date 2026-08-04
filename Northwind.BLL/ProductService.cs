using Northwind.DAL.Models;
using Northwind.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class ProductService
    {
        public List<Products> GetAllProducts()
        {
            using (var db = new NorthwindContext())
            {
                return db.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
            }
        }

        public Products GetProductByID(int id)
        {
            using (var db=new NorthwindContext())
            {
                return db.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefault(p => p.ProductID == id);
            }
        }

        public void CreateProduct(Products products)
        {
            products.ProductName = products.ProductName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Products.Add(products);
                db.SaveChanges();
            }
        }

        public void UpdateProduct(Products products)
        {
            products.ProductName = products.ProductName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(products).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var db = new NorthwindContext())
            {
                var products = db.Products.Find(id);
                if (products != null)
                {
                    db.Products.Remove(products);
                    db.SaveChanges();
                }
            }
        }
    }
}
