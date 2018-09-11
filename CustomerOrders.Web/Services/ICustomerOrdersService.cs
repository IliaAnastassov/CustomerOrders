using CustomerOrders.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrders.Web.Services
{
    public interface ICustomerOrdersService
    {
        Task<List<Customer>> GetCustomers(string requestUri);
        Task<Customer> GetCustomer(string requestUri);
        Task<List<Order>> GetOrders(string requestUri);
        void SetOrderProperties(List<Order> orders);
    }
}
