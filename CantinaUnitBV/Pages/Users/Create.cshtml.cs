 #nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CantinaUnitBV.Models;
using Microsoft.EntityFrameworkCore;
using CantinaUnitBV.Pages.Users;

namespace CantinaUnitBV.Pages
{
    public class CreateModel : RolePakageModel
    {
        private readonly CantinaUnitBV.Models.UserContext _context;
        public List<SelectListItem> Roles;
        public CreateModel(CantinaUnitBV.Models.UserContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            //Roles = await _context.Roles.Select(prop => new SelectListItem
            //{
            //    Value = prop.Id.ToString(),
            //    Text = prop.Name
            //}).ToListAsync();

            PopulateRoleDropDownList(_context);

            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                s => s.Email, s => s.Password, s => s.FirstName, s => s.SecondName, s => s.RoleId))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateRoleDropDownList(_context, emptyUser.RoleId);
            return Page();

        }
        
    }
}
