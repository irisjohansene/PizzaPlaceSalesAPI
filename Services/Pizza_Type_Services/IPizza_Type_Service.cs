using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Services.Pizza_Type_Services
{
    public interface IPizza_Type_Service
    {
        Task AddPizzaTypeAsync(Pizza_Type pt);
        Task<List<Pizza_Type>> GetAllPizzaTypeAsync();
        Task RemovePizzaTypeAsync(Pizza_Type pt);
        Task UpdatePizzaTypeAsync(Pizza_Type pt);
    }
}