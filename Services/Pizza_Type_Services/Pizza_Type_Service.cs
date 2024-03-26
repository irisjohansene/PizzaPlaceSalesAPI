using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;
using PizzaPlaceSalesAPI.Repositories;

namespace PizzaPlaceSalesAPI.Services.Pizza_Type_Services
{
    public class Pizza_Type_Service : IPizza_Type_Service
    {
        private readonly Pizza_Type_Repository _repo;
        private readonly AppDbContext _db;
        public Pizza_Type_Service(Pizza_Type_Repository repo, AppDbContext db)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<List<Pizza_Type>> GetAllPizzaTypeAsync()
        {
            var pts = await _repo.GetAllAsListAsync();
            return pts;
        }

        public async Task AddPizzaTypeAsync(Pizza_Type pt)
        {
            await _repo.AddAsync(pt);
            await _repo.CompleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePizzaTypeAsync(Pizza_Type pt)
        {
            _db.Pizza_Types.Update(pt);
            await _db.SaveChangesAsync();
        }

        public async Task RemovePizzaTypeAsync(Pizza_Type pt)
        {
            _db.Pizza_Types.Remove(pt);
            await _db.SaveChangesAsync();
        }
    }
}
