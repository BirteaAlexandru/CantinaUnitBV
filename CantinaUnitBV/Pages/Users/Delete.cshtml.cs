#nullable disable
using ApplicationServices.Services.Users;
using ApplicationServices.Services.Users.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CantinaUnitBV.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(IUserService userService,
                           ILogger<DeleteModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        private readonly IUserService _userService;

        [BindProperty]
        public UserResponse User { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _userService.GetUserById(id);
            User = result.Value;
            if (User == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        
    }
}
