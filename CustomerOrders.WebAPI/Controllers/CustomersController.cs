using AutoMapper;
using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Models;
using System.Collections.Generic;
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
            return Mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
