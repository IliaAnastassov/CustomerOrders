using CustomerOrders.Web.Constants;
using CustomerOrders.Web.Models;
using CustomerOrders.Web.ViewModels;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            var requestUri = GetRequestUri(ApiEndpoints.Customers);
            var customers = await GetCustomers(requestUri);

            return View(customers);
        }

        public async Task<ActionResult> Details(string id)
        {
            var customerRequestUri = GetRequestUri(string.Format(ApiEndpoints.CustomerDetails, id));
            var customer = await GetCustomer(customerRequestUri);

            var ordersRequestUri = GetRequestUri(string.Format(ApiEndpoints.CustomerOrders, id));
            var orders = await GetOrders(ordersRequestUri);

            foreach (var order in orders)
            {
                order.Total = GetTotalForOrder(order);
                order.ProductCount = order.OrderDetails.Sum(o => o.Quantity);
            }

            var model = new HomeDetailsViewModel();
            model.Customer = customer;
            model.Orders = orders;

            return View(model);
        }

        private decimal GetTotalForOrder(Order order)
        {
            decimal total = 0;
            foreach (var orderDetail in order.OrderDetails)
            {
                var beforeDiscount = orderDetail.Quantity * orderDetail.UnitPrice;
                total += beforeDiscount - (decimal)orderDetail.Discount * beforeDiscount;
            }

            return total;
        }

        private async Task<List<Customer>> GetCustomers(string requestUri)
        {
            var customers = new List<Customer>();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadAsAsync<List<Customer>>();
            }

            return customers;
        }

        private async Task<Customer> GetCustomer(string requestUri)
        {
            var customer = new Customer();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customer>();
            }

            return customer;
        }

        private async Task<List<Order>> GetOrders(string requestUri)
        {
            var orders = new List<Order>();
            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                orders = await response.Content.ReadAsAsync<List<Order>>();
            }

            return orders;
        }

        private string GetRequestUri(string endpoint)
        {
            return $"{ConfigurationManager.AppSettings["ApiUrl"]}{endpoint}";
        }
    }
}