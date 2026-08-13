using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }        [RequiredTrimmed]
        [StringLength(5)]
        public string CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }

        [Range(0, 1000000)]
        public decimal? Freight { get; set; }

        [StringLength(40)]
        public string ShipName { get; set; }

        [StringLength(60)]
        public string ShipAddress { get; set; }

        [StringLength(15)]
        public string ShipCity { get; set; }

        [StringLength(15)]
        public string ShipRegion { get; set; }

        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        [StringLength(15)]
        public string ShipCountry { get; set; }

        public virtual Customers Customer { get; set; }
        //public virtual Employee Employee { get; set; }
        //public virtual Shipper Shipper { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
