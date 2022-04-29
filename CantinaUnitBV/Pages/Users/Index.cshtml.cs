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
    public class IndexModel : PageModel
    {
        private readonly CantinaUnitBV.Models.UserContext _context;

        public IndexModel(CantinaUnitBV.Models.UserContext context)
        {
            _context = context;
        }
    
        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
