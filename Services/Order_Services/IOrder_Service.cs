using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Services.Order_Services
{
    public interface IOrder_Service
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetAllOrderAsync();
        Task<Order> GetOrderByOrderIdAsync(int orderId);
        Task RemoveOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}