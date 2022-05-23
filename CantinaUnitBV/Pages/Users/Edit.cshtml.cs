﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CantinaUnitBV.Pages.Users;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Responses;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Roles;

namespace CantinaUnitBV.Pages
{
    public class EditModel : RolePakageModel
    {

        public EditModel(IUserService userService, IRoleService roleService)
        {
            UserService = userService;
            RoleService = roleService;
        }

        public UserResponse UserResponse { get; set; }
        [BindProperty]
        public UpdateUserRequest UpdateUserRequest { get; set; }
        public List<SelectListItem> Roles;
        private IUserService UserService { get; }
        private readonly IRoleService RoleService;
        
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await UserService.GetUserById(id);
            UserResponse = result.Value;

            if (UserResponse == null)
            {
                return NotFound();
            }

            UpdateUserRequest = new UpdateUserRequest
            {
                FirstName = UserResponse.FirstName,
                SecondName = UserResponse.SecondName,
                RoleId = UserResponse.RoleId,
            };  

            var roles = await RoleService.GetAllRoles();

            Roles = roles.Select(prop => new SelectListItem
            {
                Value = prop.Id.ToString(),
                Text = prop.Name,
                Selected = (prop.Id == UserResponse.RoleId )
            }).ToList();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        

        
    }
}
