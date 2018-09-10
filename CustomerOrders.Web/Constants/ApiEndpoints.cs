using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.Web.Constants
{
    public class ApiEndpoints
    {
        public const string Customers = "/api/customers";
        public const string CustomerDetails = "/api/customer/{0}";
        public const string CustomerOrders = "/api/customer/{0}/orders";
    }
}