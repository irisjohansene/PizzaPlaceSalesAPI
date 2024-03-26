using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Models
{
    public class Pizza
    {
        public string Pizza_Id { get; set; }
        public string Pizza_Type_Id { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public Pizza_Type Pizza_Type { get; set; }
        public List<Order_Detail> Order_Details { get; set; }
    }
}
