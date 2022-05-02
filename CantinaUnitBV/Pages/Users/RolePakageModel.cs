using CantinaUnitBV.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CantinaUnitBV.Pages.Users
{
    public class RolePakageModel : PageModel
    {
        public SelectList RoleSL { get; set; }

        public void PopulateRoleDropDownList(UserContext _context,
            object selectedRole = null)
        {
            var rolesQuery = from d in _context.Roles
                                   orderby d.Name // Sort by name.
                                   select d;

            RoleSL = new SelectList(rolesQuery.AsNoTracking(),
                        "Id", "Name", selectedRole);
        }
    }
    
}
