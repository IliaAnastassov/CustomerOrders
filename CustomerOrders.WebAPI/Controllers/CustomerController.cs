using AutoMapper;
using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CustomerOrders.WebAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly IRepository _repository;

        public CustomerController(IRepository repository)
        {
            _repository = repository;
        }

        [Route("~/api/customers")]
        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _repository.GetAllCustomers();
            return Mapper.Map<List<CustomerDto>>(customers);
        }

        [Route("{id:alpha}")]
        public CustomerDto Get(string id)
        {
            var customer = _repository.GetCustomer(id);
            return Mapper.Map<CustomerDto>(customer);
        }

        [Route("{customerId}/orders")]
        public IEnumerable<OrderDto> GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);
            return Mapper.Map<List<OrderDto>>(orders);
        }
    }
}
