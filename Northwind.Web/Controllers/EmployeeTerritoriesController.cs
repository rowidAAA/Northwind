using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class EmployeeTerritoriesController : Controller
    {
        private EmployeeTerritoryService employeeTerritoryService = new EmployeeTerritoryService();
        private EmployeeService employeeService = new EmployeeService();
        private TerritoryService territoryService = new TerritoryService();

        public ActionResult Index()
        {
            return View(employeeTerritoryService.GetAll());
        }

        public ActionResult Create()
        {
            LoadDropdowns(null, null);
            return PartialView("Create", new EmployeeTerritory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeTerritory employeeTerritory)
        {
            if (employeeTerritoryService.Exists(employeeTerritory.EmployeeID, employeeTerritory.TerritoryID))
            {
                ModelState.AddModelError("", "That employee is already assigned to this territory.");
            }

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                LoadDropdowns(employeeTerritory.EmployeeID, employeeTerritory.TerritoryID);
                return PartialView("Create", employeeTerritory);
            }

            try
            {
                employeeTerritoryService.Create(employeeTerritory);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save the assignment.");
                Response.StatusCode = 400;
                LoadDropdowns(employeeTerritory.EmployeeID, employeeTerritory.TerritoryID);
                return PartialView("Create", employeeTerritory);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(int employeeId, string territoryId)
        {
            var employeeTerritory = employeeTerritoryService.GetByID(employeeId, territoryId);
            if (employeeTerritory == null)
                return HttpNotFound();

            return PartialView("Delete", employeeTerritory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int employeeId, string territoryId)
        {
            try
            {
                employeeTerritoryService.Delete(employeeId, territoryId);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete the assignment.");
                Response.StatusCode = 400;
                return PartialView("Delete", employeeTerritoryService.GetByID(employeeId, territoryId));
            }

            return new HttpStatusCodeResult(200);
        }

        private void LoadDropdowns(int? employeeId, string territoryId)
        {
            ViewBag.EmployeeID = new SelectList(employeeService.GetAllEmployees(), "EmployeeID", "LastName", employeeId);
            ViewBag.TerritoryID = new SelectList(territoryService.GetAllTerritories(), "TerritoryID", "TerritoryDescription", territoryId);
        }
    }
}
