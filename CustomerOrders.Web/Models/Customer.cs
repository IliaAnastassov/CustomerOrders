using System.ComponentModel.DataAnnotations;

namespace CustomerOrders.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number of Orders")]
        public int NumberOfOrders { get; set; }
    }
}