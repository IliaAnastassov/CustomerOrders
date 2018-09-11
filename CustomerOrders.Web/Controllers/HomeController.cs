using CustomerOrders.Web.Constants;
using CustomerOrders.Web.Services;
using CustomerOrders.Web.ViewModels;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerOrders.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerOrdersService _service;

        public HomeController(ICustomerOrdersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            var requestUri = GetRequestUri(ApiEndpoints.CUSTOMERS);
            var customers = await _service.GetCustomers(requestUri);

            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> Index(string customerNameKeyword)
        {
            var requestUri = GetRequestUri(ApiEndpoints.CUSTOMERS);
            var customers = await _service.GetCustomers(requestUri);

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
            var customer = await _service.GetCustomer(customerRequestUri);

            if (customer.CustomerID == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var ordersRequestUri = GetRequestUri(string.Format(ApiEndpoints.CUSTOMER_ORDERS, id));
            var orders = await _service.GetOrders(ordersRequestUri);
            _service.SetOrderProperties(orders);

            var model = new HomeDetailsViewModel();
            model.Customer = customer;
            model.Orders = orders;

            return View(model);
        }

        private string GetRequestUri(string endpoint)
        {
            return $"{ConfigurationManager.AppSettings["ApiUrl"]}{endpoint}";
        }
    }
}