using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class CustomerService
    {
        public List<Customers> GetAllCustomers()
        {
            using (var db = new NorthwindContext())
            {
                return db.Customers.ToList();
            }
        }

        public Customers GetCustomerByID(string id)
        {
            using (var db = new NorthwindContext())
            {
                return db.Customers.FirstOrDefault(c => c.CustomerID == id);
            }
        }

        public void CreateCustomer(Customers customer)
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public void UpdateCustomer(Customers customer)
        {
            customer.CompanyName = customer.CompanyName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteCustomer(string id)
        {
            using (var db = new NorthwindContext())
            {
                var customer = db.Customers.Find(id);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }
        }
    }
}
