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

            var result = await RecipeService.GetRecipeById(id);
            RecipeDto = result.Value;

            if (RecipeDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
