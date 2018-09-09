using CustomerOrders.Data;
using CustomerOrders.Data.Interfaces;
using System.Collections.Generic;
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

        public Customer GetCustomer(string id)
        {
            var customer = _repository.GetCustomer(id);
            return customer;
        }

        [Route("customer/{customerId}/orders")]
        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            return _repository.GetOrdersByCustomerId(customerId);
        }
    }
}
