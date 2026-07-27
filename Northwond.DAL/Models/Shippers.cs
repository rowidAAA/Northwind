using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Shippers
    {
        [Key]
        public int shipperID { get; set; }
        public string companyName { get; set; }
        public int phone { get; set; }
    }
}
