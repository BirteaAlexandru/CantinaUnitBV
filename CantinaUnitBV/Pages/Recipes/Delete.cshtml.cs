using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Recipes.Response;

namespace CantinaUnitBV.Pages.Recipes
{
    public class DeleteModel : PageModel
    {

        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(IRecipeService userService,
                           ILogger<DeleteModel> logger)
        {
            _recipeService = userService;
            _logger = logger;
        }
        private readonly IRecipeService _recipeService;

        [BindProperty]
        public RecipeResponse Recipe { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _recipeService.GetRecipeById(id);
            if (Recipe == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            await _recipeService.DeleteRecipe(id);
            return RedirectToPage("./Index");

        }
    }
}
