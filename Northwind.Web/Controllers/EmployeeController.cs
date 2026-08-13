using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();

        public ActionResult Index()
        {
            return View(employeeService.GetAllEmployees());
        }

        public ActionResult Create()
        {
            ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName");
            return PartialView("Create", new Employees());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employee.ReportsTo);
                return PartialView("Create", employee);
            }

            try
            {
                employeeService.CreateEmployee(employee);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save employee.");
                Response.StatusCode = 400;
                ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employee.ReportsTo);
                return PartialView("Create", employee);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeService.GetEmployeeByID(id);
            if (employee == null)
                return HttpNotFound();

            ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employee.ReportsTo);
            return PartialView("Edit", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employee.ReportsTo);
                return PartialView("Edit", employee);
            }

            try
            {
                employeeService.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save employee.");
                Response.StatusCode = 400;
                ViewBag.ReportsTo = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employee.ReportsTo);
                return PartialView("Edit", employee);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployeeByID(id);
            if (employee == null)
                return HttpNotFound();

            return PartialView("Delete", employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                employeeService.DeleteEmployee(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — employee may still have orders or manage other employees.");
                Response.StatusCode = 400;
                return PartialView("Delete", employeeService.GetEmployeeByID(id));
            }

            return new HttpStatusCodeResult(200);
        }
    }
}
