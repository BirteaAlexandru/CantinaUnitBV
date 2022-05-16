using ApplicationServices.Services.Recipes.Request;
using ApplicationServices.Services.Recipes.Response;

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
