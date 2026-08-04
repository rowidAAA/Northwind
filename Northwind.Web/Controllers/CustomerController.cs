using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService customerService = new CustomerService();
        // GET: Customer
        public ActionResult Index()
        {
            return View(customerService.GetAllCustomers());
        }

        public ActionResult Create()
        {
            return PartialView("Create", new Customers());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Create", customer);
            }
            try
            {
                customerService.CreateCustomer(customer);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save — that customer ID may already exist.");
                Response.StatusCode = 400;
                return PartialView("Create", customer);
            }
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(string id)
        {
            var customer = customerService.GetCustomerByID(id);
            if (customer == null)
                return HttpNotFound();
            return PartialView("Edit", customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Edit", customer);
            }

            try
            {
                customerService.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save customer.");
                Response.StatusCode = 400;
                return PartialView("Edit", customer);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(string id)
        {
            var customer = customerService.GetCustomerByID(id);
            if (customer == null)
                return HttpNotFound();
            return PartialView("Delete", customer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                customerService.DeleteCustomer(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — customer may still have existing orders.");
                Response.StatusCode = 400;
                var customer = customerService.GetCustomerByID(id);
                return PartialView("Delete", customer);
            }

            return new HttpStatusCodeResult(200);
        }
    }
}