using CustomerOrders.Web.Controllers;
using CustomerOrders.Web.Models;
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
        public async Task Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = await controller.Index();
            var customers = result.Model as List<Customer>;

            // Assert
            Assert.IsTrue(customers.Any());
        }
    }
}
