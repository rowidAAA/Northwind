using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Northwond.DAL.Models
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }
        public string categotyName { get; set; }
        public string description { get; set; }
        public byte[] picture { get; set; }
    }
}
