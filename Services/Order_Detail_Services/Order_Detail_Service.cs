using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;
using PizzaPlaceSalesAPI.Repositories;

namespace PizzaPlaceSalesAPI.Services.Order_Detail_Services
{
    public class Order_Detail_Service : IOrder_Detail_Service
    {
        private readonly Order_Detail_Repository _repo;
        private readonly AppDbContext _db;
        public Order_Detail_Service(Order_Detail_Repository repo, AppDbContext db)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<List<Order_Detail>> GetAllOrderDetailAsync()
        {
            var ods = await _repo.GetAllAsListAsync();
            return ods;
        }

        public async Task AddOrderDetailAsync(Order_Detail od)
        {
            await _repo.AddAsync(od);
            await _repo.CompleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(Order_Detail od)
        {
            _db.Order_Details.Update(od);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveOrderDetailAsync(Order_Detail od)
        {
            _db.Order_Details.Remove(od);
            await _db.SaveChangesAsync();
        }
    }
}
