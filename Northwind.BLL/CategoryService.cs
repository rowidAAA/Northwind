using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
                    c.CategoryName = c.CategoryName?.Trim();
                }
                return categories;
            }
        }

        public Category GetCategoryByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (category != null)
                {
                    category.CategoryName = category.CategoryName?.Trim();
                }
                return category;
            }
        }

        public void CreateCategory(Category category)
        {
            category.CategoryName = category.CategoryName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            category.CategoryName = category.CategoryName?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string id)
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.Find(id);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
            }
        }
    }
}
