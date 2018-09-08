using CustomerOrders.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CustomerOrders.Data.Repositories
{
    public class DisconnectedRepository : IRepository
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var context = new CustomerOrdersContext())
            {
                return context.Customers.AsNoTracking()
                                        .Include(c => c.Orders)
                                        .OrderBy(c => c.ContactName)
                                        .ToList();
            }
        }

        public Customer GetCustomer(string id)
        {
            using (var context = new CustomerOrdersContext())
            {
                return context.Customers.Find(id);
            }
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            using (var context = new CustomerOrdersContext())
            {
                return context.Orders.AsNoTracking()
                                     .Where(o => o.CustomerID == id)
                                     .ToList();
            }
        }
    }
}
