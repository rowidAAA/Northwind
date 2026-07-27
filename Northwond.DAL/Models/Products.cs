using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Products
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; }
        public int supplierID { get; set; }
        public int categoryID { get; set; }
        public int quantityPerUnit { get; set; }
        public double unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int reorderLevel { get; set; }
        public bool discontinued { get; set; }
    }
}
