#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Responses;

namespace CantinaUnitBV.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel(IUserService userService)
        {
            UserService = userService;
        }
    
        public IList<UserResponse> Users { get;set; }
        private  IUserService UserService { get; }

        public async Task OnGetAsync()
        {
            var users = await UserService.GetAllUsers();

            Users = users.ToList();
        }
    }
}
