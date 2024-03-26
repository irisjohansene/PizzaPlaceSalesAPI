using PizzaPlaceSalesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PizzaPlaceSalesAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _db;
        public AppDbContext db { get { return _db; } }
        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _db.Set<TEntity>().AddRangeAsync(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);

        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public List<TEntity> GetAllAsList()
        {
            return _db.Set<TEntity>().ToList();
        }

        public async Task<List<TEntity>> GetAllAsListAsync()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await (Task.FromResult(_db.Set<TEntity>()));
        }

        public void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.FromResult(_db.Set<TEntity>().Remove(entity));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
            await _db.SaveChangesAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().SingleOrDefault();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().SingleOrDefaultAsync();
        }

        public void Complete()
        {
            _db.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
