using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL
{
    public class NorthwindContext: DbContext
    {
        public NorthwindContext() : base("name=NorthwindEntities")
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTerritory>().HasKey(et => new { et.EmployeeID, et.TerritoryID });

            modelBuilder.Entity<OrderDetails>().HasKey(od => new { od.OrderID, od.ProductID });
        }
    }
}
