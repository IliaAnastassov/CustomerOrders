namespace CustomerOrders.Web.Models
{
    public class Product
    {
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
    }
}