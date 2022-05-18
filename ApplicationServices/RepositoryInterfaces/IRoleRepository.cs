using Domain;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<ICollection<Role>> GetRolesAsync();
    }
}
