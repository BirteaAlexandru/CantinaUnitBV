using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using ApplicationServices.RepositoryInterfaces;
using Persistence.Repositories.Base;
using Domain.Search;
using ApplicationServices.Base;
using System.Linq.Expressions;
using ApplicationServices.RepositoryInterfaces.Generics;

namespace Persistence.Repositories
{
    internal class OrderRepository : RepositoryWithSearch<Order>, IOrderRepository
    {
        public OrderRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<IPartialCollection<Order>> GetOrderAsync(SearchArgs searchArgs)
        {
            Expression<Func<Order, bool>>? predicate = null;

            if (!string.IsNullOrWhiteSpace(searchArgs.SearchText))
            {
                var searchText = RemoveDiacritics(searchArgs.SearchText);

                predicate = p => EF.Functions.Collate(p.User.FirstName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText);
                predicate = predicate.Or(p => EF.Functions.Collate(p.User.SecondName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText));
               }

            var sortExpression = string.Equals(searchArgs.SortOption.PropertyName, "RoleName", StringComparison.InvariantCultureIgnoreCase)
                ? p => p.User.FirstName
                : SortExpression(searchArgs, "Id");

            if (predicate == null)
            {
                return await GetAllAsync(searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);
            }

            return await GetAllByAsync(predicate, searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);

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
