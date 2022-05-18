using ApplicationServices.Base;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using Domain.Base;
using Domain.Search;

namespace ApplicationServices.Services.Users
{
    public interface IUserService
    {
        Task<PartialCollectionResponse<UserResponse>> SearchUsers(SearchArgs searchArgs);
        Task<Result<UserResponse>> GetUserById(long? id);
        Task<Result> AddUser(CreateUserRequest request);
        Task<Result> UpdateUser(long Id, UpdateUserRequest request);
        Task<Result> DeleteUser(long? userId);
    }
}
