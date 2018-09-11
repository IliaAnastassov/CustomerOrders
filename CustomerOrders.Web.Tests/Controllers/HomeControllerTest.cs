using CustomerOrders.Web.Controllers;
using CustomerOrders.Web.Models;
using CustomerOrders.Web.Services;
using CustomerOrders.Web.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerOrders.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public async Task IndexShouldGetCustomers()
        {
            var mockService = MockRepository.Mock<ICustomerOrdersService>();
            mockService.Stub(async m => await m.GetCustomers())
                                               .Return(Task.FromResult(new List<Customer>()));
            var controller = new HomeController(mockService);

            ViewResult result = await controller.Index();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DetailsShouldGetCustomerDetails()
        {
            var mockService = MockRepository.Mock<ICustomerOrdersService>();
            mockService.Stub(async m => await m.GetCustomer(Arg<string>.Is.Anything))
                                               .Return(Task.FromResult(new Customer { CustomerID = "Test" }));
            mockService.Stub(async m => await m.GetOrders(Arg<string>.Is.Anything))
                                               .Return(Task.FromResult(new List<Order>()));
            var controller = new HomeController(mockService);

            ViewResult result = await controller.Details(string.Empty) as ViewResult;
            var model = result.Model as HomeDetailsViewModel;

            Assert.That(model.Customer, Is.Not.Null);
            Assert.That(model.Orders, Is.Not.Null);
        }

        [Test]
        public async Task DetailsShouldRedirectToIndexWhenPassedEmpty()
        {
            var mockService = MockRepository.Mock<ICustomerOrdersService>();
            mockService.Stub(async m => await m.GetCustomer(Arg<string>.Is.Anything))
                                               .Return(Task.FromResult(new Customer()));
            var controller = new HomeController(mockService);

            RedirectToRouteResult result = await controller.Details(string.Empty) as RedirectToRouteResult;
            var route = result.RouteValues.Values.First();

            Assert.That("Index", Is.EqualTo(route));
        }
    }
}
