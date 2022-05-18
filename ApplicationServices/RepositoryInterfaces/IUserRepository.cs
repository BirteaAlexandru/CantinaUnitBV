using ApplicationServices.RepositoryInterfaces.Generics;
using Domain.Search;
using Domain.Users;

namespace ApplicationServices.RepositoryInterfaces
{
    public  interface IUserRepository : IRepository<User>
    {
        Task<IPartialCollection<User>> GetUsersAsync(SearchArgs searchArgs);
        Task<User?> GetUserByIdAsync(long? id, bool isTracked = false);
       
    }
}
