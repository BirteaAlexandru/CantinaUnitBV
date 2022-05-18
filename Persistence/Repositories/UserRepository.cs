using ApplicationServices.RepositoryInterfaces;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using ApplicationServices.RepositoryInterfaces.Generics;
using Domain.Search;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    internal class UserRepository : RepositoryWithSearch<User>, IUserRepository
    {
        public UserRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<IPartialCollection<User>> GetUsersAsync(SearchArgs searchArgs)
        {
            Expression<Func<User, bool>>? predicate = null;

            if (!string.IsNullOrWhiteSpace(searchArgs.SearchText))
            {
                var searchText = RemoveDiacritics(searchArgs.SearchText);

                predicate = p => EF.Functions.Collate(p.FirstName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText);
                predicate = predicate.Or(p => EF.Functions.Collate(p.SecondName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText));
                predicate = predicate.Or(p => EF.Functions.Collate(p.FirstName + " " + p.SecondName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText));
                predicate = predicate.Or(p => EF.Functions.Collate(p.SecondName + " " + p.FirstName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText));
            }

            var sortExpression = string.Equals(searchArgs.SortOption.PropertyName, "RoleName", StringComparison.InvariantCultureIgnoreCase) 
                ? p => p.Role.Name 
                : SortExpression(searchArgs, "Id");

            if (predicate == null)
            {
                return await GetAllAsync(searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);
            }

            return await GetAllByAsync(predicate, searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);
        }

        public async Task<User?> GetUserByIdAsync(long? id, bool isTracked = false)
        {
            var user = await GetByIdAsync(id);

            return user;
        }

        
        protected override IQueryable<User> DefaultIncludes(IQueryable<User> queryable)
        {
            var query = queryable.Include(p => p.Role);

            return query;
        }
    }
}
