using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrders.WebAPI.Models
{
    public class OrderDetailDto
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public ProductDto Product { get; set; }
    }
}