using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Repositories
{
    public class Order_Repository : Repository<Order>
    {
        private readonly AppDbContext _db;

        public Order_Repository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
