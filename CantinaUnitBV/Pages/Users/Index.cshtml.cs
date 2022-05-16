#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CantinaUnitBV.Pages.Users;

public class IndexModel : PageModel
{
    public Task OnGetAsync()
    {
        return Task.CompletedTask;
    }
}