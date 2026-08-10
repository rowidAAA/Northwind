using System;
using System.Web.Mvc;
using Northwind.BLL;
using Northwind.DAL.Models;

namespace Northwind.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        private OrderDetailService detailService = new OrderDetailService();
        private ProductService productService = new ProductService();

        public ActionResult Create(int orderId)
        {
            ViewBag.Products = productService.GetAllProducts();
            return PartialView(new OrderDetails { OrderID = orderId, Quantity = 1 });
        }

        [HttpPost]
        public ActionResult Create(OrderDetails detail)
        {
            if (detailService.Exists(detail.OrderID, detail.ProductID))
            {
                ModelState.AddModelError("ProductID", "This product is already on the order.");
            }

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                ViewBag.Products = productService.GetAllProducts();
                return PartialView(detail);
            }

            try
            {
                detailService.Create(detail);
                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Could not save line item: " + ex.Message);
                Response.StatusCode = 400;
                ViewBag.Products = productService.GetAllProducts();
                return PartialView(detail);
            }
        }

        [HttpPost]
        public ActionResult Delete(int orderId, int productId)
        {
            detailService.Delete(orderId, productId);
            return new HttpStatusCodeResult(200);
        }
    }
}