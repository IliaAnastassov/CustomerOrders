using CustomerOrders.Data.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CustomerOrders.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly CustomerOrdersContext _context = new CustomerOrdersContext();

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.AsNoTracking()
                                    .OrderBy(c => c.ContactName)
                                    .ToList();
        }

        public Customer GetCustomer(string id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            return _context.Orders.AsNoTracking()
                                 .Include(o => o.Order_Details)
                                 .Where(o => o.CustomerID == id)
                                 .ToList();
        }
    }
}
