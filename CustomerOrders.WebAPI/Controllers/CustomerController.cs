using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CustomerOrders.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        public CustomerDto GetCustomer(string id)
        {
            var customer = _repository.GetCustomer(id);

            var orderDtos = customer.Orders.Select(
                o => new OrderDto
                {
                    OrderID = o.OrderID,
                    CustomerID = o.CustomerID
                }).ToList();

            var customerDto = new CustomerDto
            {
                CustomerID = customer.CustomerID,
                ContactName = customer.ContactName,
                CompanyName = customer.CompanyName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Orders = orderDtos
            };

            return customerDto;
        }

        [Route("api/customer/{customerId}/orders")]
        public IEnumerable<OrderDto> GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);

            var orderDtos = orders.Select(
                o => new OrderDto
                {
                    OrderID = o.OrderID,
                    CustomerID = o.CustomerID
                }).ToList();

            return orderDtos;
        }
    }
}
