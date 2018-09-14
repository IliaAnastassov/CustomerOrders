using System.Collections.Generic;
using CustomerOrders.Data;
using CustomerOrders.WebAPI.Models;

namespace CustomerOrders.WebAPI.Services
{
    public interface IMapperService
    {
        IEnumerable<CustomerDto> Map(IEnumerable<Customer> customers);
        CustomerDto Map(Customer customer);
        IEnumerable<OrderDto> Map(IEnumerable<Order> orders);
    }
}