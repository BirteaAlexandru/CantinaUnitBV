using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationServices.Services.Recipes.Response;
using ApplicationServices.Services.Recipes;

namespace CantinaUnitBV.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        [BindProperty]
        public RecipeResponse RecipeDto { get; set; }
        private IRecipeService RecipeService { get; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RecipeDto = await RecipeService.GetRecipeById(id);

            if (RecipeDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
