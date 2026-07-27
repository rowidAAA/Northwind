using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Models
{
    public class Region
    {
        [Key]
        public int regionID { get; set; }
        public string regionDescription { get; set; }
    }
}
