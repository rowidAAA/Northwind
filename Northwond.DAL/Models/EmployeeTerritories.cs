using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Key, Column(Order = 0)]
        public int EmployeeID { get; set; }

        [Key, Column(Order = 1)]
        [RequiredTrimmed]
        public string TerritoryID { get; set; }

        [ForeignKey("EmployeeID")]
        public virtual Employees Employee { get; set; }

        [ForeignKey("TerritoryID")]
        public virtual Territory Territory { get; set; }
    }
}
