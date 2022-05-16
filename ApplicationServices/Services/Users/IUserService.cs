using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using Domain;

namespace ApplicationServices.Services.Users
{
    public interface IUserService
    {
        Task<ICollection<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUserById(long? id);
        Task AddUser(CreateUserRequest request);
        Task UpdateUser(long Id, UpdateUserRequest request);
        Task<bool> DeleteUser(long? id);
    }
}
