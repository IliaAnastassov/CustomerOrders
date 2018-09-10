using System.Collections.Generic;

namespace CustomerOrders.Web.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public decimal Total { get; set; }
        public int ProductCount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}