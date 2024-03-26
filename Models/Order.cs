using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public List<Order_Detail> Order_Details { get; set; }
    }
}
