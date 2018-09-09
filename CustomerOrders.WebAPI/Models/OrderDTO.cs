using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.WebAPI.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}