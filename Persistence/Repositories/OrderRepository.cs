using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using ApplicationServices.RepositoryInterfaces;

namespace Persistence.Repositories
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<ICollection<Order>> GetOrderAsync()
        {
            var order = await GetAllAsync();

            return order;
        }

        public async Task<Order> GetOrderByIdAsync(long? id, bool isTracked = false)
        {
            var order = await GetByIdAsync(id);
       
            return order;
        }

        protected override IQueryable<Order> DefaultIncludes(IQueryable<Order> queryable)
        {
            var query = queryable.Include(p => p.RecipesOrders)
                .Include(p=>p.User)
                .Include(p => p.RecipesOrders)
                .ThenInclude(p => p.Recipe);

            return query;
        }
    }
}
