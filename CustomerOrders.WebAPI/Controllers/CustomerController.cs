using CustomerOrders.Data;
using CustomerOrders.Data.Interfaces;
using CustomerOrders.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerOrders.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IRepository _repo = new DisconnectedRepository();

        public Customer GetCustomer(string id)
        {
            return _repo.GetCustomer(id);
        }

        [Route("customer/{customerId}/orders")]
        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            return _repo.GetOrdersByCustomerId(customerId);
        }
    }
}
