using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.WebAPI.Models
{
    public class CustomerDTO
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public ICollection<OrderDTO> Orders { get; set; }
    }
}