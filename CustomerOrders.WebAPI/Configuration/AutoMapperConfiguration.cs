using AutoMapper;
using CustomerOrders.Data;
using CustomerOrders.WebAPI.Models;

namespace CustomerOrders.WebAPI.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, CustomerDto>();
                config.CreateMap<Order, OrderDto>()
                      .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Order_Details));
                config.CreateMap<Order_Detail, OrderDetailDto>();
                config.CreateMap<Product, ProductDto>();
            });
        }
    }
}