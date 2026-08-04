using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Northwind.Web.Controllers
{
    public class RegionsController : Controller
    {
        private RegionService regionService = new RegionService();
        // GET: Regions
        public ActionResult Index()
        {
            return View(regionService.GetAllRegions());
        }
        public ActionResult Details(int id)
        {
            var region = regionService.GetRegionByID(id);
            if (region == null)
                return HttpNotFound();
            return View(region);
        }
        public ActionResult Create()
        {
            return PartialView("Create", new Region());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Region region)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Create", region);
            }
            try
            {
                regionService.CreateRegion(region);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save — that Region ID may already exist.");
                Response.StatusCode = 400;
                return PartialView("Create", region);
            }
            return new HttpStatusCodeResult(200);
        }
        public ActionResult Update(int id)
        {
            var region = regionService.GetRegionByID(id);
            if (region == null)
                return HttpNotFound();
            return View(region);
        }
        [HttpPost]
        public ActionResult Update(Region region)
        {
            regionService.UpdateRegion(region);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var region = regionService.GetRegionByID(id);
            if (region == null)
                return HttpNotFound();
            return PartialView("Delete", region);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var region = regionService.GetRegionByID(id);
            try
            {
                regionService.DeleteRegion(id);
            }
            catch (RegionInUseException ex)
            {
                Response.StatusCode = 400;
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("Delete", region);
            }
            return new HttpStatusCodeResult(200);
        }
    }
}