using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Request;

namespace CantinaUnitBV.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        public CreateModel(IRecipeService recipeService)
        {

            _recipeService = recipeService;
        }
        private readonly IRecipeService _recipeService;
        public async Task<IActionResult> OnGet()
        {

            return Page();
        }

        [BindProperty]
        public CreateRecipeRequest CreateRecipeRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyRecipe = new CreateRecipeRequest();

            if (await TryUpdateModelAsync<CreateRecipeRequest>(
                emptyRecipe,
                "CreateRecipeRequest",   // Prefix for form value.
                s => s.Name, s => s.Price, s => s.Ingredients, s => s.Quantity, s => s.Available))
            {
                await _recipeService.AddRecipe(emptyRecipe);
                return RedirectToPage("./Index");
            }

            return Page();

        }

    }
}
