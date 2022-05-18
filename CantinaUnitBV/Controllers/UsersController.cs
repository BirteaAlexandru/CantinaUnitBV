using ApplicationServices.Base;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using CantinaUnitBV.Controllers.Base;
using Domain.Search;
using Infastructure.DataTables;
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

    [HttpPost("search")]
    [ProducesResponseType(typeof(DtResult<UserResponse>), 200)]
    public async Task<IActionResult> SearchUsers([FromBody] DtParameters dtParameters)
    {
        var searchArgs = new SearchArgs
        {
            SearchText = dtParameters.Search.Value,
            Offset = dtParameters.Start,
            Limit = dtParameters.Length,
            SortOption = ComposeSort(dtParameters)
        };

        var users = await _userService.SearchUsers(searchArgs);

        return new JsonResult(new DtResult<UserResponse>
        {
            Draw = dtParameters.Draw,
            RecordsTotal = users.RecordsTotal,
            RecordsFiltered = users.RecordsFiltered,
            Data = users.Values,
        });
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