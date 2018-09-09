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

        public CustomerDTO GetCustomer(string id)
        {
            var customer = _repository.GetCustomer(id);

            var orderDtos = customer.Orders.Select(
                o => new OrderDTO
                {
                    OrderID = o.OrderID,
                    CustomerID = o.CustomerID
                }).ToList();

            var customerDto = new CustomerDTO
            {
                CustomerID = customer.CustomerID,
                ContactName = customer.ContactName,
                Orders = orderDtos
            };

            return customerDto;
        }

        [Route("api/customer/{customerId}/orders")]
        public IEnumerable<OrderDTO> GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);

            var orderDtos = orders.Select(
                o => new OrderDTO
                {
                    OrderID = o.OrderID,
                    CustomerID = o.CustomerID
                }).ToList();

            return orderDtos;
        }
    }
}
