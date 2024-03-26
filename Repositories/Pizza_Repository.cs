using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Repositories
{
    public class Pizza_Repository : Repository<Pizza>
    {
        private readonly AppDbContext _db;

        public Pizza_Repository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
