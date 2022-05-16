using ApplicationServices.Services.Users.Responses;

namespace ApplicationServices.Services.Roles
{
    public interface IRoleService
    {
        Task<ICollection<RoleResponse>> GetAllRoles();
    }
}
