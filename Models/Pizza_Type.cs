using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceSalesAPI.Models
{
    public class Pizza_Type
    {
        public string Pizza_Type_Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}