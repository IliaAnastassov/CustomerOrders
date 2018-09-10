using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CustomerOrders.WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IRepository _repository;

        public CustomersController(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _repository.GetAllCustomers();

            var customerDtos = customers.Select(
                c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    ContactName = c.ContactName,
                    Orders = c.Orders.Select(
                        o => new OrderDto
                        {
                            OrderID = o.OrderID,
                            CustomerID = o.CustomerID
                        }).ToList()
                }).ToList();

            return customerDtos;
        }
    }
}
