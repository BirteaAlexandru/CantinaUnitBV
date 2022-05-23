#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Response;

namespace CantinaUnitBV.Pages.Recipes
{
    public class IndexModel : PageModel
    {

        public IndexModel(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public IList<RecipeResponse> Recipe { get; set; }
        private IRecipeService RecipeService { get; }

        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }
    }
}
