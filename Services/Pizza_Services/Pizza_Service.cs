using Microsoft.EntityFrameworkCore;
using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;
using PizzaPlaceSalesAPI.Repositories;

namespace PizzaPlaceSalesAPI.Services.Pizza_Services
{
    public class Pizza_Service : IPizza_Service
    {
        private readonly Pizza_Repository _repo;
        private readonly AppDbContext _db;
        public Pizza_Service(Pizza_Repository repo, AppDbContext db)
        {
            _db = db;
            _repo = repo;
        }

        public async Task<List<Pizza>> GetAllPizzaAsync()
        {
            var pizzas = await _repo.GetAllAsListAsync();
            return pizzas;
        }

        public async Task<Pizza> GetPizzaByPizzaIdAsync(string pizza_Id)
        {
            var pizza = await _repo.GetAsync(x => x.Pizza_Id == pizza_Id);
            await _db.Pizza_Types.Where(x => x.Pizza_Type_Id == pizza.Pizza_Id).LoadAsync();
            return pizza;
        }

        public async Task AddPizzaAsync(Pizza pizza)
        {
            await _repo.AddAsync(pizza);
            await _repo.CompleteAsync();
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePizzaAsync(Pizza pizza)
        {
            _db.Pizzas.Update(pizza);
            await _db.SaveChangesAsync();
        }

        public async Task RemovePizzaAsync(Pizza pizza)
        {
            _db.Pizzas.Remove(pizza);
            await _db.SaveChangesAsync();
        }
    }
}
