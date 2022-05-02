#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CantinaUnitBV.Models;
using CantinaUnitBV.Pages.Users;

namespace CantinaUnitBV.Pages
{
    public class EditModel : RolePakageModel
    {
        private readonly CantinaUnitBV.Models.UserContext _context;

        public EditModel(CantinaUnitBV.Models.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users
            .Include(c => c.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            PopulateRoleDropDownList(_context, User.RoleId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Users.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                studentToUpdate,
                "user",
                s => s.FirstName, s => s.SecondName, s => s.Email, s => s.Password, s => s.RoleId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateRoleDropDownList(_context, studentToUpdate.RoleId);
            return Page();
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
