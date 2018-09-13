using CustomerOrders.Web.Services;
using CustomerOrders.Web.ViewModels;
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
            var customers = await _service.GetCustomers();
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> Index(string customerNameKeyword)
        {
            var customers = await _service.GetCustomers();

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
            var customer = await _service.GetCustomer(id);

            if (string.IsNullOrEmpty(customer.CustomerID))
            {
                return RedirectToAction(nameof(Index));
            }

            var orders = await _service.GetOrders(id);
            _service.SetOrderProperties(orders);

            var model = new HomeDetailsViewModel();
            model.Customer = customer;
            model.Orders = orders;

            return View(model);
        }
    }
}