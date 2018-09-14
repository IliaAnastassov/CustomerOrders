using System.Collections.Generic;
using CustomerOrders.Web.Models;

namespace CustomerOrders.Web.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}