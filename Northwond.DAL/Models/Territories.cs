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
        [RequiredTrimmed]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [RequiredTrimmed]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }
    }
}
