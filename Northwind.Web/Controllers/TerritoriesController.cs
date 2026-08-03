using Northwind.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.DAL.Models;

namespace Northwind.Web.Controllers
{
    
    public class TerritoriesController : Controller
    {
        private TerritoryService territoryService = new TerritoryService();
        // GET: Territories
        public ActionResult Index()
        {
            return View(territoryService.GetAllTerritories());
        }

        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(territoryService.GetAllRegions(), "RegionID", "RegionDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Territory territory)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RegionID = new SelectList(territoryService.GetAllRegions(), "RegionID", "RegionDescription", territory.RegionID);
                return View(territory);
            }

            try
            {
                territoryService.CreateTerritory(territory);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save — that Territory ID may already exist.");
                ViewBag.RegionID = new SelectList(territoryService.GetAllRegions(), "RegionID", "RegionDescription", territory.RegionID);
                return View(territory);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var territory = territoryService.GetTerritoryByID(id);
            if (territory == null)
                return HttpNotFound();
            ViewBag.RegionID = new SelectList(territoryService.GetAllRegions(), "RegionID", "RegionDescription", territory.RegionID);
            return PartialView("Edit", territory);
        }

        [HttpPost]
        public ActionResult Edit(Territory territory)
        {
            territoryService.UpdateTerritory(territory);
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(string id)
        {
            var territory = territoryService.GetTerritoryByID(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", territory);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            territoryService.DeleteTerritory(id);
            return new HttpStatusCodeResult(200);
        }
    }
}