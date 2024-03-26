using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Models
{
    public class Order_Detail
    {
        public int Order_Detail_Id { get; set; }
        public int Order_Id { get; set; }
        public string Pizza_Id { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Pizza Pizza { get; set; }
    }
}
