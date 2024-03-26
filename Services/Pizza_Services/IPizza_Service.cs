using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Services.Pizza_Services
{
    public interface IPizza_Service
    {
        Task AddPizzaAsync(Pizza pizza);
        Task<List<Pizza>> GetAllPizzaAsync();
        Task<Pizza> GetPizzaByPizzaIdAsync(string pizzaId);
        Task RemovePizzaAsync(Pizza pizza);
        Task UpdatePizzaAsync(Pizza pizza);
    }
}