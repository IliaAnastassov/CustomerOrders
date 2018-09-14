using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CustomerOrders.Data.Interfaces;

namespace CustomerOrders.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly CustomerOrdersContext _context = new CustomerOrdersContext();

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            customers = _context.Customers.AsNoTracking()
                                          .OrderBy(c => c.ContactName)
                                          .ToList();

            return customers;
        }

        public Customer GetCustomer(string id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            var orders = new List<Order>();
            orders = _context.Orders.AsNoTracking()
                                    .Include(o => o.Order_Details)
                                    .Where(o => o.CustomerID == id)
                                    .ToList();

            return orders;
        }
    }
}
