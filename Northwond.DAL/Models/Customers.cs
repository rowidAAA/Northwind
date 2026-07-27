using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Customers
    {
        [Key]
        public int customersID { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public int postalcode { get; set; }
        public string country { get; set; }
        public int phone { get; set; }
        public int fax { get; set; }

    }
}
