using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.Services.Users.Responses;
using Microsoft.Extensions.Logging;

namespace ApplicationServices.Services.Roles
{
    public class RoleService : Service, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository, ILogger<RoleService> logger) : base(logger)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ICollection<RoleResponse>> GetAllRoles()
        {
            var users = await _roleRepository.GetRolesAsync();

            return users.Select(p => new RoleResponse
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }
    }
}
