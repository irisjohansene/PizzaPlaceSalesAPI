using System.Linq.Expressions;

namespace PizzaPlaceSalesAPI.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        Task<IQueryable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        void Complete();
        Task CompleteAsync();
    }

}
