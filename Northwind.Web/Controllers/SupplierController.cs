using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BLL;
using Northwind.DAL.Models;

namespace Northwind.Web.Controllers
{
    public class SupplierController : Controller
    {
        private SupplierService supplierService = new SupplierService();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(supplierService.GetAllSuppliers());
        }

        public ActionResult Create()
        {
            return PartialView("Create", new Suppliers());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers supplier)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Create", supplier);
            }

            try
            {
                supplierService.CreateSupplier(supplier);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save supplier.");
                Response.StatusCode = 400;
                return PartialView("Create", supplier);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            if (supplier == null)
                return HttpNotFound();
            return PartialView("Edit", supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suppliers supplier)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Edit", supplier);
            }

            try
            {
                supplierService.UpdateSupplier(supplier);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save supplier.");
                Response.StatusCode = 400;
                return PartialView("Edit", supplier);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(int id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            if (supplier == null)
                return HttpNotFound();
            return PartialView("Delete", supplier);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                supplierService.DeleteSupplier(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — supplier may still have related products.");
                Response.StatusCode = 400;
                var supplier = supplierService.GetSupplierByID(id);
                return PartialView("Delete", supplier);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}