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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Region region)
        {
            regionService.CreateRegion(region);
            return RedirectToAction("Index");
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
            return View(region);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            regionService.DeleteRegion(id);
            return RedirectToAction("Index");

        }
    }
}