using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using Domain;
using Microsoft.Extensions.Logging;


namespace ApplicationServices.Services.Users
{
    public class UserService : Service, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger) : base(logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return users.Select(p => new UserResponse
            {
                Id = p.Id,
                Email = p.Email,
                FirstName = p.FirstName,
                SecondName = p.SecondName,
                RoleName = p.Role.Name
            }).ToList();
        }
        public async Task<UserResponse> GetUserById(long? id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                RoleId = user.Role.Id,
                RoleName = user.Role.Name
            };
        }

        public async Task AddUser(CreateUserRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var user = new User()
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                RoleId = request.RoleId
            };

            await _userRepository.AddAsync(user);

            await scope.SaveAsync();
            await scope.CommitAsync();


        }

        public async Task UpdateUser(long userId, UpdateUserRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new Exception($"Cannot find user with Id {userId}");
            }

            user.FirstName = request.FirstName;
            user.SecondName = request.SecondName;
            user.RoleId = request.RoleId;


            await _userRepository.UpdateAsync(user);

            await scope.SaveAsync();
            await scope.CommitAsync();
        }

        public async Task<bool> DeleteUser(long? id)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var user = await _userRepository.GetUserByIdAsync(id);
            _userRepository.Delete(user);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return true;
        }
    }
}
