using System.Linq;
using System.Web.Mvc;
using Northwind.BLL;

namespace Northwind.Web.Controllers
{
    public class HomeController : Controller
    {
        private RegionService regionService = new RegionService();
        private TerritoryService territoryService = new TerritoryService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();
        private ProductService productService = new ProductService();
        private CustomerService customerService = new CustomerService();
        private EmployeeService employeeService = new EmployeeService();
        private ShipperService shipperService = new ShipperService();
        private OrderService orderService = new OrderService();

        public ActionResult Index()
        {
            ViewBag.RegionCount = regionService.GetAllRegions().Count;
            ViewBag.TerritoryCount = territoryService.GetAllTerritories().Count;
            ViewBag.CategoryCount = categoryService.GetAllCategories().Count;
            ViewBag.SupplierCount = supplierService.GetAllSuppliers().Count;
            ViewBag.ProductCount = productService.GetAllProducts().Count;
            ViewBag.CustomerCount = customerService.GetAllCustomers().Count;
            ViewBag.EmployeeCount = employeeService.GetAllEmployees().Count;
            ViewBag.ShipperCount = shipperService.GetAllShippers().Count;
            ViewBag.OrderCount = orderService.GetAll().Count;

            var products = productService.GetAllProducts();
            ViewBag.LowStockCount = products.Count(p => p.UnitsInStock < p.ReorderLevel);

            return View();
        }
    }
}