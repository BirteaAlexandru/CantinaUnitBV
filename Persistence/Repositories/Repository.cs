using ApplicationServices.RepositoryInterfaces;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;


namespace Persistence.Repositories
{
    public abstract class Repository<TEntity>: IRepository<TEntity>
        where TEntity : Entity
    {
        protected Repository([NotNull] CantinaBvContext context)
        {
            Context = context;
        }

        protected CantinaBvContext Context { get; }
        private DbSet<TEntity> Entities => Context.Set<TEntity>();

        private IQueryable<TEntity> EntityQuery => Entities;

        public virtual Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return DefaultIncludes(EntityQuery)
                .Includes(includes)
                .ToListAsync();
        }

        public virtual Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = EntityQuery.Where(predicate);

            return DefaultIncludes(queryable)
                .Includes(includes)
                .ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(long? id, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = EntityQuery.Where(p => p.Id.Equals(id));

            return DefaultIncludes(queryable)
                .Includes(includes)
                .SingleOrDefaultAsync();
        }

        public virtual Task<TEntity> GetFirstIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = EntityQuery.Where(predicate);

            return DefaultIncludes(queryable)
                .Includes(includes)
                .FirstOrDefaultAsync();
        }

        public virtual Task<bool> ExistAsync(long id)
        {
            return Entities.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await Entities.AddAsync(entity);

            return result.Entity;
        }

        public async Task<IReadOnlyCollection<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            var returnEntities = new List<TEntity>();

            foreach (var entity in entities)
            {
                var returnEntity = await AddAsync(entity);
                returnEntities.Add(returnEntity);
            }

            return returnEntities;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = Entities.Update(entity).Entity;
            return Task.FromResult(updatedEntity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        protected virtual IQueryable<TEntity> DefaultIncludes(IQueryable<TEntity> queryable)
        {
            return queryable;
        }
    }

    public static class QueryableExtension
    {
        public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> query,
            params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity
        {
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }
}
