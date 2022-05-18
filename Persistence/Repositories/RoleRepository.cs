using Domain;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using ApplicationServices.RepositoryInterfaces;

namespace Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<ICollection<Role>> GetRolesAsync()
        {
            var roles = await GetAllAsync();

            return roles;
        }
    }
}
