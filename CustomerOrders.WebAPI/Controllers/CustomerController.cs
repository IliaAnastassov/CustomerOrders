using AutoMapper;
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
            return Mapper.Map<CustomerDto>(customer);
        }

        [Route("api/customer/{customerId}/orders")]
        public IEnumerable<OrderDto> GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);
            return Mapper.Map<List<OrderDto>>(orders);
        }
    }
}
