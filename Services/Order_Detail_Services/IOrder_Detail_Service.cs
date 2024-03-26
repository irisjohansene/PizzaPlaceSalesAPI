using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Services.Order_Detail_Services
{
    public interface IOrder_Detail_Service
    {
        Task AddOrderDetailAsync(Order_Detail od);
        Task<List<Order_Detail>> GetAllOrderDetailAsync();
        Task RemoveOrderDetailAsync(Order_Detail od);
        Task UpdateOrderDetailAsync(Order_Detail od);
    }
}