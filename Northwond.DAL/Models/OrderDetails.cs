using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class OrderDetails
    {
        public int orderID { get; set; }
        public int productID { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
    }
}
