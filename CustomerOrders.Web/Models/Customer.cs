using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Web.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        [Display(Name = "Number of Orders")]
        public int NumberOfOrders { get { return Orders.Count; } }

        public ICollection<Order> Orders { get; set; }
    }
}