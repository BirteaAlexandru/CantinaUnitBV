using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Response;
using ApplicationServices.Services.Recipes.Request;

namespace CantinaUnitBV.Pages.Recipes
{
    public class EditModel : PageModel
    {

        public EditModel(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public RecipeResponse RecipeResponse { get; set; }
        [BindProperty]
        public CreateRecipeRequest CreateRecipeRequest { get; set; }
        private IRecipeService RecipeService { get; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeResponse = await RecipeService.GetRecipeById(id);

            if (RecipeResponse == null)
            {
                return NotFound();
            }

            CreateRecipeRequest = new CreateRecipeRequest
            {
                Name = RecipeResponse.Name,
                Price = RecipeResponse.Price,
                Ingredients = RecipeResponse.Ingredients,
                Available = RecipeResponse.Available,
                Quantity = RecipeResponse.Quantity,
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(long id)
        {
            var emptyRecipe = new CreateRecipeRequest();

            if (await TryUpdateModelAsync<CreateRecipeRequest>(
                emptyRecipe,
                "CreateRecipeRequest",   // Prefix for form value.
                  s => s.Name, s => s.Price, s => s.Ingredients, s => s.Quantity, s => s.Available))
            {
                await RecipeService.UpdateRecipe(id, emptyRecipe);
                return RedirectToPage("./Index");
            }
            return Page();
        }

        //private bool UserExists(long id)
        //{
        //    return _context.Users.Any(e => e.Id == id);

        //}
    }
}
