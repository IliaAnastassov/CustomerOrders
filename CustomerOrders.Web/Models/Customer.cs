using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Web.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        [Display(Name = "Customer Name")]
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Number of Orders")]
        public int NumberOfOrders { get { return Orders.Count; } }

        public ICollection<Order> Orders { get; set; }
    }
}