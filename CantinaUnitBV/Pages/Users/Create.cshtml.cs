#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CantinaUnitBV.Models;

namespace CantinaUnitBV.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CantinaUnitBV.Models.UserContext _context;

        public CreateModel(CantinaUnitBV.Models.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new User();

            if (await TryUpdateModelAsync<User>(
                emptyStudent,
                "user",   // Prefix for form value.
                s => s.Email, s => s.Password, s => s.FirstName, s => s.SecondName))
            {
                _context.Users.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
