#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CantinaUnitBV.Pages
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(IUserService userService)
        {
            UserService = userService;
        }

        [BindProperty]
        public UserResponse UserDto { get; set; }
        private IUserService UserService { get; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserDto = await UserService.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
