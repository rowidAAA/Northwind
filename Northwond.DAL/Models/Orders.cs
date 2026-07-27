using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Orders
    {
        [Key]
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int employeeID { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime shippedDate { get; set; }
        public int shipVia { get; set; }
        public double freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipRegion { get; set; }
        public int shipPostalCode { get; set; }
        public string shipCountry { get; set; }
    }
}
