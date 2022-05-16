using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using Domain.Base;

namespace ApplicationServices.Services.Users
{
    public interface IUserService
    {
        Task<ICollection<UserResponse>> GetAllUsers();
        Task<Result<UserResponse>> GetUserById(long? id);
        Task<Result> AddUser(CreateUserRequest request);
        Task<Result> UpdateUser(long Id, UpdateUserRequest request);
        Task<Result> DeleteUser(long? userId);
    }
}
