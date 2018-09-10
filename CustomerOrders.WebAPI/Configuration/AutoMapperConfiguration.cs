using AutoMapper;
using CustomerOrders.Data;
using CustomerOrders.WebAPI.Models;

namespace CustomerOrders.WebAPI.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config => config.CreateMap<Customer, CustomerDto>());
            Mapper.Initialize(config => config.CreateMap<Order, OrderDto>());
            Mapper.Initialize(config => config.CreateMap<Order_Detail, OrderDetailDto>());
            Mapper.Initialize(config => config.CreateMap<Product, ProductDto>());
        }
    }
}