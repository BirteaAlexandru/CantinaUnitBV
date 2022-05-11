using ApplicationServices.Services.Users;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CantinaUnitBV.Pages.Users
{
    public class RolePakageModel : PageModel
    {
        public SelectList RoleSL { get; set; }

        public void PopulateRoleDropDownList(IUserService userService,
            object selectedRole = null)
        {
            //var rolesQuery = from d in userService.Role
            //                       orderby d.Name // Sort by name.
            //                       select d;

            //RoleSL = new SelectList(rolesQuery.AsNoTracking(),
            //            "Id", "Name", selectedRole);
        }
    }
    
}
