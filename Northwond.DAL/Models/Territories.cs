using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Territories
    {
        [Key]
        public int territoryID { get; set; }
        public string territoryDescription { get; set; }
        public int regionID { get; set; }
    }
}
