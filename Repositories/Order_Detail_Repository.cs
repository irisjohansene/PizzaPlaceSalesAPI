using PizzaPlaceSalesAPI.Data;
using PizzaPlaceSalesAPI.Models;

namespace PizzaPlaceSalesAPI.Repositories
{
    public class Order_Detail_Repository : Repository<Order_Detail>
    {
        private readonly AppDbContext _db;

        public Order_Detail_Repository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
