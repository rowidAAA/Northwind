using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("Shippers")]
    public class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [RequiredTrimmed]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [PhoneNumber]
        [StringLength(24)]
        public string Phone { get; set; }
    }
}
