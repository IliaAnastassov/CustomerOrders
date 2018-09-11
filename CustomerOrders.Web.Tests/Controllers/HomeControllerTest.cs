using CustomerOrders.Web.Controllers;
using CustomerOrders.Web.Models;
using CustomerOrders.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerOrders.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task IndexShouldGetCustomers()
        {
            var controller = new HomeController();

            ViewResult result = await controller.Index();
            var customers = result.Model as List<Customer>;

            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public async Task DetailsShouldGetCustomerDetails()
        {
            var controller = new HomeController();

            ViewResult result = await controller.Details("ROMEY") as ViewResult;
            var model = result.Model as HomeDetailsViewModel;

            Assert.AreEqual(5, model.Customer.NumberOfOrders);
        }

        [TestMethod]
        public async Task DetailsShouldRedirectToIndexWhenPassedEmpty()
        {
            var controller = new HomeController();

            RedirectToRouteResult result = await controller.Details(string.Empty) as RedirectToRouteResult;
            var route = result.RouteValues.Values.First();

            Assert.AreEqual("Index", route);
        }
    }
}
