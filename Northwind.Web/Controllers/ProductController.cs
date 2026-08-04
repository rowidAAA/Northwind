using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();
        // GET: Product
        public ActionResult Index(int? categoryID, int? supplierID)
        {
            var products = productService.GetAllProducts().AsEnumerable();
            if (categoryID.HasValue)
            {
                products = products.Where(p => p.CategoryID == categoryID.Value);
            }
            if (supplierID.HasValue)
            {
                products = products.Where(p => p.SupplierID == supplierID.Value);
            }
            ViewBag.CategoryFilter = new SelectList(categoryService.GetAllCategories(), "CategoryID", "CategoryName", categoryID);
            ViewBag.SupplierFilter = new SelectList(supplierService.GetAllSuppliers(), "SupplierID", "CompanyName", supplierID);
            return View(products.ToList());
        }

        private void PopulateDropdowns(Products product = null)
        {
            ViewBag.CategoryID = new SelectList(categoryService.GetAllCategories(), "CategoryID", "CategoryName", product?.CategoryID);
            ViewBag.SupplierID = new SelectList(supplierService.GetAllSuppliers(), "SupplierID", "CompanyName", product?.SupplierID);
        }

        public ActionResult Create()
        {
            PopulateDropdowns();
            return PartialView("Create", new Products());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(product);
                Response.StatusCode = 400;
                return PartialView("Create", product);
            }

            try
            {
                productService.CreateProduct(product);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save product.");
                PopulateDropdowns(product);
                Response.StatusCode = 400;
                return PartialView("Create", product);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            var product = productService.GetProductByID(id);
            if (product == null)
                return HttpNotFound();
            PopulateDropdowns(product);
            return PartialView("Edit", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products product)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(product);
                Response.StatusCode = 400;
                return PartialView("Edit", product);
            }

            try
            {
                productService.UpdateProduct(product);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save product.");
                PopulateDropdowns(product);
                Response.StatusCode = 400;
                return PartialView("Edit", product);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(int id)
        {
            var product = productService.GetProductByID(id);
            if (product == null)
                return HttpNotFound();
            return PartialView("Delete", product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                productService.DeleteProduct(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — product may be referenced by existing orders.");
                Response.StatusCode = 400;
                var product = productService.GetProductByID(id);
                return PartialView("Delete", product);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}