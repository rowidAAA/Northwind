using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [RequiredTrimmed]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Range(0, 1000000)]
        public decimal? UnitPrice { get; set; }

        [Range(0, 32767)]
        public short? UnitsInStock { get; set; }

        [Range(0, 32767)]
        public short? UnitsOnOrder { get; set; }

        [Range(0, 32767)]
        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Suppliers Supplier { get; set; }
    }
}
