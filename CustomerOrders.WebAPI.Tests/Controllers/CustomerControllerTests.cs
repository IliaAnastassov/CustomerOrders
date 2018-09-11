using CustomerOrders.Data;
using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Controllers;
using CustomerOrders.WebAPI.Models;
using CustomerOrders.WebAPI.Services;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;

namespace CustomerOrders.WebAPI.Tests.Controllers
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void ShouldGetAllCustomers()
        {
            var repositoryMock = MockRepository.Mock<IRepository>();
            repositoryMock.Stub(r => r.GetAllCustomers())
                          .Return(new List<Customer>());
            var mapperMock = MockRepository.Mock<IMapperService>();
            mapperMock.Stub(m => m.Map(new List<Customer>()))
                      .Return(new List<CustomerDto>());
            var controller = new CustomerController(repositoryMock, mapperMock);

            var result = controller.GetAll();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ShouldGetCustomerById()
        {
            var repositoryMock = MockRepository.Mock<IRepository>();
            repositoryMock.Stub(r => r.GetCustomer(Arg<string>.Is.Anything))
                          .Return(new Customer());
            var mapperMock = MockRepository.Mock<IMapperService>();
            mapperMock.Stub(m => m.Map(new Customer()))
                      .Return(new CustomerDto());
            var controller = new CustomerController(repositoryMock, mapperMock);

            var result = controller.Get(string.Empty);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ShouldGetOrdersByCustomerId()
        {
            var repositoryMock = MockRepository.Mock<IRepository>();
            repositoryMock.Stub(r => r.GetOrdersByCustomerId(Arg<string>.Is.Anything))
                          .Return(new List<Order>());
            var mapperMock = MockRepository.Mock<IMapperService>();
            mapperMock.Stub(m => m.Map(new List<Order>()))
                      .Return(new List<OrderDto>());
            var controller = new CustomerController(repositoryMock, mapperMock);

            var result = controller.GetOrdersByCustomerId(string.Empty);

            Assert.That(result, Is.Not.Null);
        }
    }
}
