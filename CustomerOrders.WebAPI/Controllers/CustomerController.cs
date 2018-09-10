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
        public IHttpActionResult GetAll()
        {
            var customers = _repository.GetAllCustomers();
            var customerDtos = Mapper.Map<List<CustomerDto>>(customers);

            return Ok(customerDtos);
        }

        [Route("{id:alpha}")]
        public IHttpActionResult Get(string id)
        {
            var customer = _repository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = Mapper.Map<CustomerDto>(customer);

            return Ok(customerDto);
        }

        [Route("{customerId}/orders")]
        public IHttpActionResult GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);
            var orderDtos = Mapper.Map<List<OrderDto>>(orders);

            return Ok(orderDtos);
        }
    }
}
