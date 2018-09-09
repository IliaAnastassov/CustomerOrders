using System.Collections.Generic;

namespace CustomerOrders.Web.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}