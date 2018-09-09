using CustomerOrders.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Shmuley Boteach", NumberOfOrders = 6 },
                new Customer { Id = 2, Name = "Dildo Schwaggins", NumberOfOrders = 2 },
                new Customer { Id = 3, Name = "Skank Hunt", NumberOfOrders = 4 },
                new Customer { Id = 4, Name = "Palma Hayek", NumberOfOrders = 12 },
                new Customer { Id = 5, Name = "John Doe", NumberOfOrders = 31 },
                new Customer { Id = 6, Name = "Nignog Johnson", NumberOfOrders = 7 }
            };

            return View(customers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}