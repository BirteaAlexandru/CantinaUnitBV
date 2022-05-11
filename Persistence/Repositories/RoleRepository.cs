using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
