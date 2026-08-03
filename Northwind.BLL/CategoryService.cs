using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class CategoryService
    {
        public List<Category> GetAllCategories()
        {
            using (var db = new NorthwindContext())
            {
                var categories = db.Categories.ToList();
                foreach (var c in categories)
                {
                    c.Description = c.Description?.Trim();
                }
                return categories;
            }
        }
    }
}
