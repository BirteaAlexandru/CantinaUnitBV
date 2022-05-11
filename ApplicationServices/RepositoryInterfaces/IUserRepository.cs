using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public  interface IUserRepository : IRepository<User>
    {
        Task<ICollection<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(long? id, bool isTracked = false);
       
    }
}
