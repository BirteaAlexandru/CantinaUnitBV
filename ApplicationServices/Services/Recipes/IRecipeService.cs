using ApplicationServices.Services.Recipes.Request;
using ApplicationServices.Services.Recipes.Response;
using Domain.Base;

namespace ApplicationServices.Services.Recipes
{
    public interface IRecipeService
    {
        Task<ICollection<RecipeResponse>> GetAllRecipes();
        Task<Result<RecipeResponse>> GetRecipeById(long? id);
        Task<Result> AddRecipe(CreateRecipeRequest request);
        Task<Result> UpdateRecipe(long Id, CreateRecipeRequest request);
        Task<Result> DeleteRecipe(long? id);

    }
}
