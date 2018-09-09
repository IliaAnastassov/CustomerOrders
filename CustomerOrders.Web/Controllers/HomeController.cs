using CustomerOrders.Web.Constants;
using CustomerOrders.Web.Models;
using CustomerOrders.Web.ViewModels;
using Newtonsoft.Json;
using System;
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
        private string _apiUrl = $"{ConfigurationManager.AppSettings["ApiUrl"]}{ApiEndpoints.Customers}";
        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_apiUrl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            var customers = new List<Customer>();
            var model = new List<HomeIndexViewModel>();
            var responseMessage = await _client.GetAsync(_apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(responseData);
                model = customers.Select(
                    c => new HomeIndexViewModel
                    {
                        Id = c.CustomerID,
                        Name = c.ContactName,
                        NumberOfOrders = c.Orders.Count
                    }).ToList();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}