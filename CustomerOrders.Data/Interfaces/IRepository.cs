using System.Collections.Generic;

namespace CustomerOrders.Data.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(string id);
        IEnumerable<Order> GetOrdersByCustomerId(string id);
    }
}
