using System.Web.Http;
using CustomerOrders.Data.Interfaces;
using CustomerOrders.WebAPI.Services;

namespace CustomerOrders.WebAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private IRepository _repository;
        private IMapperService _mapperService;

        public CustomerController(IRepository repository, IMapperService mapperService)
        {
            _repository = repository;
            _mapperService = mapperService;
        }

        [Route("~/api/customers")]
        public IHttpActionResult GetAll()
        {
            var customers = _repository.GetAllCustomers();
            var customerDtos = _mapperService.Map(customers);

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

            var customerDto = _mapperService.Map(customer);

            return Ok(customerDto);
        }

        [Route("{customerId}/orders")]
        public IHttpActionResult GetOrdersByCustomerId(string customerId)
        {
            var orders = _repository.GetOrdersByCustomerId(customerId);
            var orderDtos = _mapperService.Map(orders);

            return Ok(orderDtos);
        }
    }
}
