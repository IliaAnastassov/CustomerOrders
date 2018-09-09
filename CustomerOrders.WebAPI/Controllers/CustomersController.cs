using CustomerOrders.Data;
using CustomerOrders.Data.Interfaces;
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

        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetAllCustomers();
        }
    }
}
