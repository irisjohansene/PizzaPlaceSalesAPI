using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Repositories
{
    public class Pizza_Type_Repository : Repository<Pizza_Type>
    {
        private readonly AppDbContext _db;

        public Pizza_Type_Repository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
