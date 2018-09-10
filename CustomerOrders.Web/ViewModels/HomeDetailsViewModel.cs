using CustomerOrders.Web.Models;
using System.Collections.Generic;

namespace CustomerOrders.Web.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}