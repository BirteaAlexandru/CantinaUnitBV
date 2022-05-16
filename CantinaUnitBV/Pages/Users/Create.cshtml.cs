 #nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Request;
using ApplicationServices.Services.Roles;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Requests;
using ApplicationServices.Services.Users.Responses;
using CantinaUnitBV.Pages.Users;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CantinaUnitBV.Pages
{
    public class CreateModel : PageModel
    {
        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public async Task<IActionResult> OnGet()
        {
            var roles = await _roleService.GetAllRoles();

            Roles = roles.Select(prop => new SelectListItem
            {
                Value = prop.Id.ToString(),
                Text = prop.Name
            }).ToList();


            return Page();
        }

        [BindProperty]
        public CreateUserRequest CreateUserRequest { get; set; }
        public List<SelectListItem> Roles;

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new CreateUserRequest();

            if (await TryUpdateModelAsync<CreateUserRequest>(
                emptyUser,
                "CreateUserRequest",   // Prefix for form value.
                s => s.Email, s => s.Password, s => s.FirstName, s => s.SecondName, s => s.RoleId))
            {
                await _userService.AddUser(emptyUser);
                return RedirectToPage("./Index");
            }
            
           
            return Page();


          
        }
        
    }
}
