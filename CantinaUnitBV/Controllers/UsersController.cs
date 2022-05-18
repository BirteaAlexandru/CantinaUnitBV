using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Requests;
using CantinaUnitBV.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUnitBV.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : CantinaBvControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsers();

        return Ok(users);
    }

    [HttpGet("{userId:long:required}")]
    public async Task<IActionResult> GetUserById([FromRoute] long userId)
    {
        var user = await _userService.GetUserById(userId);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _userService.AddUser(request);

        return FromResult(result);
    }

    [HttpPut("{userId:long:required}")]
    public async Task<IActionResult> UpdateUser([FromRoute] long userId, [FromBody] UpdateUserRequest request)
    {
        var result = await _userService.UpdateUser(userId, request);

        return FromResult(result);
    }


    [HttpDelete("{userId:long:required}")]
    public async Task<IActionResult> DeleteUser([FromRoute] long userId)
    {
        var result = await _userService.DeleteUser(userId);

        return FromResult(result);
    }
}