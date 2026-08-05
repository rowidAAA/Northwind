using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Quantity { get; set; }

        public float Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
