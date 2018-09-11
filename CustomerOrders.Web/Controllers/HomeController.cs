using CustomerOrders.Web.Constants;
using CustomerOrders.Web.Messages;
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

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var requestUri = GetRequestUri(ApiEndpoints.CUSTOMERS);
            var customers = await GetCustomers(requestUri);

            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> Index(string customerNameKeyword)
        {
            var requestUri = GetRequestUri(ApiEndpoints.CUSTOMERS);
            var customers = await GetCustomers(requestUri);

            if (!string.IsNullOrWhiteSpace(customerNameKeyword))
            {
                var filteredCustomers = customers.Where(c => c.ContactName.ToLower().Contains(customerNameKeyword.ToLower()))
                                                 .ToList();
                return View(filteredCustomers);
            }

            return View(customers);
        }

        public async Task<ActionResult> Details(string id)
        {
            var customerRequestUri = GetRequestUri(string.Format(ApiEndpoints.CUSTOMER_DETAILS, id));
            var customer = await GetCustomer(customerRequestUri);

            if (customer.CustomerID == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var ordersRequestUri = GetRequestUri(string.Format(ApiEndpoints.CUSTOMER_ORDERS, id));
            var orders = await GetOrders(ordersRequestUri);
            SetOrderProperties(orders);

            var model = new HomeDetailsViewModel();
            model.Customer = customer;
            model.Orders = orders;

            return View(model);
        }

        private void SetOrderProperties(List<Order> orders)
        {
            foreach (var order in orders)
            {
                order.Total = GetTotal(order);
                order.ProductCount = order.OrderDetails.Sum(o => o.Quantity);
                order.WarningMessage = GetWarningMessage(order.OrderDetails);
            }
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