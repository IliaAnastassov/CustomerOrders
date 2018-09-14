using System.Collections.Generic;

namespace CustomerOrders.WebAPI.Models
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}