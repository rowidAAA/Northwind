using System;
using System.Web.Mvc;
using Northwind.BLL;
using Northwind.DAL.Models;

namespace Northwind.Web.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService = new OrderService();
        private CustomerService customerService = new CustomerService();
        private EmployeeService employeeService = new EmployeeService();
        private ShipperService shipperService = new ShipperService();

        public ActionResult Index()
        {
            return View(orderService.GetAll());
        }

        public ActionResult Create()
        {
            LoadDropdowns();
            return View(new Order { OrderDate = DateTime.Now });
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(order);
            }

            try
            {
                var saved = orderService.Create(order);
                return RedirectToAction("Details", new { id = saved.OrderID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not save order: " + ex.Message);
                LoadDropdowns();
                return View(order);
            }
        }

        public ActionResult Details(int id)
        {
            var order = orderService.GetOrderByID(id);
            if (order == null) return HttpNotFound();
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            var order = orderService.GetOrderByID(id);
            if (order == null) return HttpNotFound();
            return PartialView("Delete", order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                orderService.Delete(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete the order.");
                Response.StatusCode = 400;
                return PartialView("Delete", orderService.GetOrderByID(id));
            }

            return new HttpStatusCodeResult(200);
        }

        private void LoadDropdowns()
        {
            ViewBag.CustomerID = new SelectList(customerService.GetAllCustomers(), "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName");
            ViewBag.ShipVia = new SelectList(shipperService.GetAllShippers(), "ShipperID", "CompanyName");
        }
    }
}