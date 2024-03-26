using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;
using PizzaPlaceSalesAPI.Repositories;

namespace PizzaPlaceSalesAPI.Services.Order_Services
{
    public class Order_Service : IOrder_Service
    {
        private readonly Order_Repository _repo;
        private readonly AppDbContext _db;
        public Order_Service(Order_Repository repo, AppDbContext db)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            var orders = await _repo.GetAllAsListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByOrderIdAsync(int orderId)
        {
            var order = await _repo.GetAsync(x => x.Order_Id == orderId);
            await _db.Order_Details.Where(x => x.Order_Id == order.Order_Id).LoadAsync();
            return order;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _repo.AddAsync(order);
            await _repo.CompleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveOrderAsync(Order order)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
        }
    }
}
