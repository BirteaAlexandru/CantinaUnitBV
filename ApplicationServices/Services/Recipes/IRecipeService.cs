using ApplicationServices.Services.Recipes.Request;
using ApplicationServices.Services.Recipes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Recipes
{
    public interface IRecipeService
    {
        Task<ICollection<RecipeResponse>> GetAllRecipes();
        Task<RecipeResponse> GetRecipeById(long? id);
        Task AddRecipe(CreateRecipeRequest request);
        Task UpdateRecipe(long Id, CreateRecipeRequest request);
        Task<bool> DeleteRecipe(long? id);

    }
}
