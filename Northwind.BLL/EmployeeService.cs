using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class EmployeeService
    {
        public List<Employees> GetAllEmployees()
        {
            using (var db = new NorthwindContext())
            {
                return db.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToList();
            }
        }

        public Employees GetEmployeeByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                return db.Employees.FirstOrDefault(e => e.EmployeeID == id);
            }
        }

        public void CreateEmployee(Employees employee)
        {
            employee.LastName = employee.LastName?.Trim();
            employee.FirstName = employee.FirstName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void UpdateEmployee(Employees employee)
        {
            employee.LastName = employee.LastName?.Trim();
            employee.FirstName = employee.FirstName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                
                db.Entry(employee).Property(e => e.Photo).IsModified = false;
                db.Entry(employee).Property(e => e.PhotoPath).IsModified = false;
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var db = new NorthwindContext())
            {
                var employee = db.Employees.Find(id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
            }
        }
    }
}
