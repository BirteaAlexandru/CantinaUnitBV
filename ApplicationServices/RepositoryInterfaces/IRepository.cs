using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(long? id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetFirstIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> ExistAsync(long id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> AddAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
