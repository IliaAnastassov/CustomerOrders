using CustomerOrders.Data;
using CustomerOrders.WebAPI.Models;
using System.Collections.Generic;

namespace CustomerOrders.WebAPI.Services
{
    public interface IMapperService
    {
        IEnumerable<CustomerDto> Map(IEnumerable<Customer> customers);
        CustomerDto Map(Customer customer);
        IEnumerable<OrderDto> Map(IEnumerable<Order> orders);
    }
}