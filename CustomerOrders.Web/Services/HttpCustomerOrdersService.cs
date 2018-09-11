using CustomerOrders.Web.Messages;
using CustomerOrders.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerOrders.Web.Services
{
    public class HttpCustomerOrdersService : ICustomerOrdersService
    {
        private HttpClient _client;

        public HttpCustomerOrdersService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Customer>> GetCustomers(string requestUri)
        {
            var customers = new List<Customer>();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }

            return customers;
        }

        public async Task<Customer> GetCustomer(string requestUri)
        {
            var customer = new Customer();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }

            return customer;
        }

        public async Task<List<Order>> GetOrders(string requestUri)
        {
            var orders = new List<Order>();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                orders = await response.Content.ReadAsAsync<List<Order>>();
            }

            return orders;
        }

        public void SetOrderProperties(List<Order> orders)
        {
            foreach (var order in orders)
            {
                order.Total = GetTotal(order);
                order.ProductCount = order.OrderDetails.Sum(o => o.Quantity);
                order.WarningMessage = GetWarningMessage(order.OrderDetails);
            }
        }

        private decimal GetTotal(Order order)
        {
            decimal total = 0;
            foreach (var orderDetail in order.OrderDetails)
            {
                var beforeDiscount = orderDetail.Quantity * orderDetail.UnitPrice;
                total += beforeDiscount - (decimal)orderDetail.Discount * beforeDiscount;
            }

            return total;
        }

        private string GetWarningMessage(IEnumerable<OrderDetail> orderDetails)
        {
            string message = string.Empty;

            if (orderDetails.Any(o => o.Product.Discontinued || o.Product.UnitsInStock < o.Product.UnitsOnOrder))
            {
                message = BusinessMessages.WARRNING;
            }

            return message;
        }
    }
}