using Northwind.BLL;
using Northwind.DAL.Models;
using System;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class ShipperController : Controller
    {
        private ShipperService shipperService = new ShipperService();

        public ActionResult Index()
        {
            return View(shipperService.GetAllShippers());
        }

        public ActionResult Create()
        {
            return PartialView("Create", new Shippers());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shippers shipper)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Create", shipper);
            }

            try
            {
                shipperService.CreateShipper(shipper);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save shipper.");
                Response.StatusCode = 400;
                return PartialView("Create", shipper);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            var shipper = shipperService.GetShipperByID(id);
            if (shipper == null)
                return HttpNotFound();

            return PartialView("Edit", shipper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Shippers shipper)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("Edit", shipper);
            }

            try
            {
                shipperService.UpdateShipper(shipper);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not save shipper.");
                Response.StatusCode = 400;
                return PartialView("Edit", shipper);
            }

            return new HttpStatusCodeResult(200);
        }

        public ActionResult Delete(int id)
        {
            var shipper = shipperService.GetShipperByID(id);
            if (shipper == null)
                return HttpNotFound();

            return PartialView("Delete", shipper);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                shipperService.DeleteShipper(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete — shipper may still have related orders.");
                Response.StatusCode = 400;
                return PartialView("Delete", shipperService.GetShipperByID(id));
            }

            return new HttpStatusCodeResult(200);
        }
    }
}
