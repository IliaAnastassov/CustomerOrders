using System.Collections.Generic;
using AutoMapper;
using CustomerOrders.Data;
using CustomerOrders.WebAPI.Models;

namespace CustomerOrders.WebAPI.Services
{
    public class DtoMapperService : IMapperService
    {
        public IEnumerable<CustomerDto> Map(IEnumerable<Customer> customers)
        {
            return Mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto Map(Customer customer)
        {
            return Mapper.Map<CustomerDto>(customer);
        }

        public IEnumerable<OrderDto> Map(IEnumerable<Order> orders)
        {
            return Mapper.Map<List<OrderDto>>(orders);
        }
    }
}