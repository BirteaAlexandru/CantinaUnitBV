using ApplicationServices.Services.Roles;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Requests;
using CantinaUnitBV.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUnitBV.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : CantinaBvControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var users = await _roleService.GetAllRoles();

        return Ok(users);
    }

   
}