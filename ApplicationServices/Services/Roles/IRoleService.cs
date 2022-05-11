using ApplicationServices.Services.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Roles
{
    public interface IRoleService
    {
        Task<ICollection<RoleResponse>> GetAllRoles();
    }
}
