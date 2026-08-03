using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService categoryService = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            return View(categoryService.GetAllCategories());
        }

        public ActionResult Create()
        {
            return PartialView("Create", new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Create", category);
            }

            try
            {
                categoryService.CreateCategory(category);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save category.");
                Response.StatusCode = 400;
                return PartialView("Create", category);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            var category = categoryService.GetCategoryByID(id);
            if (category == null)
                return HttpNotFound();
            return PartialView("Edit", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Edit", category);
            }

            try
            {
                categoryService.UpdateCategory(category);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save category.");
                Response.StatusCode = 400;
                return PartialView("Edit", category);
            }

            return new HttpStatusCodeResult(200);
        }

         public ActionResult Delete(int id)
        {
            var category = categoryService.GetCategoryByID(id);
            if (category == null)
                return HttpNotFound();
            return PartialView("Delete", category);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                categoryService.DeleteCategory(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — category may still have related products.");
                Response.StatusCode = 400;
                var category = categoryService.GetCategoryByID(id);
                return PartialView("Delete", category);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}