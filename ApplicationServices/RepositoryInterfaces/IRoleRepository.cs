using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<ICollection<Role>> GetRolesAsync();
    }
}
