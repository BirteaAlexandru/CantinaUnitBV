using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using Domain.Base;
using Domain.Search;
using Domain.Users;
using Domain.Users.ValueObjects;
using Microsoft.Extensions.Logging;


namespace ApplicationServices.Services.Users;

public class UserService : Service, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<UserService> logger) : base(logger)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PartialCollectionResponse<UserResponse>> SearchUsers(SearchArgs searchArgs)
    {
        var users = await _userRepository.GetUsersAsync(searchArgs);

        var userResponse =  users.Values.Select(p => new UserResponse
        {
            Id = p.Id,
            Email = p.Email,
            FirstName = p.FirstName,
            SecondName = p.SecondName,
            RoleName = p.Role.Name
        }).ToList();

        return new PartialCollectionResponse<UserResponse>
        {
            Values = userResponse,
            Offset = users.Offset,
            Limit = users.Limit,
            RecordsFiltered = users.Count,
            RecordsTotal = await _userRepository.CountAsync()
        };
    }

    public async Task<Result<UserResponse>> GetUserById(long? id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);


        if (user == null)
        {
            return Result.Failure<UserResponse>($"Cannot find user with Id {id}");
        }

        var response =  new UserResponse
        {
            Email = user.Email,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            RoleId = user.Role.Id,
            RoleName = user.Role.Name
        };

        return Result.Success(response);
    }

    public async Task<Result> AddUser(CreateUserRequest request)
    {

        var emailAddressOrError = Email.Create(request.Email);

        if (emailAddressOrError.IsFailure)
        {
            return Result.Failure(emailAddressOrError.Error);
        }

        var scope = await _unitOfWork.CreateScopeAsync();

        var userOrError = User.Create(emailAddressOrError.Value, request.Password, request.FirstName, request.SecondName,
            request.RoleId);

        if (userOrError.IsFailure)
        {
            return Result.Failure(userOrError.Error);
        }  

        await _userRepository.AddAsync(userOrError.Value);

        await scope.SaveAsync();
        await scope.CommitAsync();

        return Result.Success("The user was created successfully");
    }

    public async Task<Result> UpdateUser(long userId, UpdateUserRequest request)
    {
        var scope = await _unitOfWork.CreateScopeAsync();
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
        {
            return Result.Failure($"Cannot find user with Id {userId}");
        }

        var userUpdatedOrError = user.Update(request.FirstName, request.SecondName, request.RoleId);

        if (userUpdatedOrError.IsFailure)
        {
            return Result.Failure(userUpdatedOrError.Error);
        }

        await _userRepository.UpdateAsync(user);

        await scope.SaveAsync();
        await scope.CommitAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteUser(long? userId)
    {
        var scope = await _unitOfWork.CreateScopeAsync();

        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
        {
            return Result.Failure($"Cannot find user with Id {userId}");
        }

        _userRepository.Delete(user);

        await scope.SaveAsync();
        await scope.CommitAsync();

        return Result.Success();
    }
}