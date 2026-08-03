using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("Territories")]
    public class Territory
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [Required]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }
    }
}
