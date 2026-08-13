using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class EmployeeTerritoryService
    {
        public List<EmployeeTerritory> GetAll()
        {
            using (var db = new NorthwindContext())
            {
                return db.EmployeeTerritories
                    .Include(et => et.Employee)
                    .Include(et => et.Territory.Region)
                    .OrderBy(et => et.Employee.LastName)
                    .ToList();
            }
        }

        public EmployeeTerritory GetByID(int employeeId, string territoryId)
        {
            using (var db = new NorthwindContext())
            {
                return db.EmployeeTerritories
                    .Include(et => et.Employee)
                    .Include(et => et.Territory.Region)
                    .FirstOrDefault(et => et.EmployeeID == employeeId && et.TerritoryID == territoryId);
            }
        }

        public bool Exists(int employeeId, string territoryId)
        {
            using (var db = new NorthwindContext())
            {
                return db.EmployeeTerritories.Any(et => et.EmployeeID == employeeId && et.TerritoryID == territoryId);
            }
        }

        public void Create(EmployeeTerritory employeeTerritory)
        {
            using (var db = new NorthwindContext())
            {
                db.EmployeeTerritories.Add(employeeTerritory);
                db.SaveChanges();
            }
        }

        public void Delete(int employeeId, string territoryId)
        {
            using (var db = new NorthwindContext())
            {
                var employeeTerritory = db.EmployeeTerritories.Find(employeeId, territoryId);
                if (employeeTerritory != null)
                {
                    db.EmployeeTerritories.Remove(employeeTerritory);
                    db.SaveChanges();
                }
            }
        }
    }
}
