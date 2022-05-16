using Domain.Users;

namespace ApplicationServices.RepositoryInterfaces
{
    public  interface IUserRepository : IRepository<User>
    {
        Task<ICollection<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(long? id, bool isTracked = false);
       
    }
}
