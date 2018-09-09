using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number of Orders")]
        public int NumberOfOrders { get; set; }
    }
}