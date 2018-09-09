using CustomerOrders.Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                var customer = context.Customers.Find(id);
                return customer;
            }
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            using (var context = new CustomerOrdersContext())
            {
                return context.Orders.AsNoTracking()
                                     .Include(o => o.Order_Details)
                                     .Where(o => o.CustomerID == id)
                                     .ToList();
            }
        }
    }
}
