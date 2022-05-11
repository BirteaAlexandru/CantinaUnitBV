using ApplicationServices.RepositoryInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<ICollection<User>> GetUsersAsync()
        {
            var users = await GetAllAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(long? id, bool isTracked = false)
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
