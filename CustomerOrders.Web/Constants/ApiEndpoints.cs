using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.Web.Constants
{
    public class ApiEndpoints
    {
        public const string CUSTOMERS = "/api/customers";
        public const string CUSTOMER_DETAILS = "/api/customer/{0}";
        public const string CUSTOMER_ORDERS = "/api/customer/{0}/orders";
    }
}