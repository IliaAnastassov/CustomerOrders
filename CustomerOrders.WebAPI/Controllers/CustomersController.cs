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
    public class CustomersController : ApiController
    {
        private readonly IRepository _repo = new DisconnectedRepository();

        public IEnumerable<Customer> GetCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}
