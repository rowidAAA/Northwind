using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("Order Details")]
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(1, 32767)]
        public short Quantity { get; set; }

        [Range(0, 1)]
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
