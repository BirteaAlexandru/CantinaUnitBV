﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task OnGetAsync()
        {
            var recipe = await RecipeService.GetAllRecipes();

            Recipe = recipe.ToList();
        }
    }
}
