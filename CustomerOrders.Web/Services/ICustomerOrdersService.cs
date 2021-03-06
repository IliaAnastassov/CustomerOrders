﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerOrders.Web.Models;

namespace CustomerOrders.Web.Services
{
    public interface ICustomerOrdersService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string customerId);
        Task<List<Order>> GetOrders(string customerId);
        void SetOrderProperties(List<Order> orders);
    }
}
