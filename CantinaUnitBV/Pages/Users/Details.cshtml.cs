#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CantinaUnitBV.Models;

namespace CantinaUnitBV.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CantinaUnitBV.Models.UserContext _context;

        public DetailsModel(CantinaUnitBV.Models.UserContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        //    User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            User = await _context.Users
        .Include(s => s.Role)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
