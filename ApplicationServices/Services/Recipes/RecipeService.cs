using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Recipes.Response;
using Microsoft.Extensions.Logging;
using Domain;
using ApplicationServices.Services.Recipes.Request;

namespace ApplicationServices.Services.Recipes
{
    public class RecipeService: Service, IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, ILogger<RecipeService> logger) : base(logger)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<RecipeResponse>> GetAllRecipes()
        {
            var recipe = await _recipeRepository.GetRecipesAsync();

            return recipe.Select(p => new RecipeResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Ingredients = p.Ingredients,
                Available = p.Available,
                Quantity = p.Quantity,
            }).ToList();
        }
        public async Task<RecipeResponse> GetRecipeById(long? id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            return new RecipeResponse
            {
                Name = recipe.Name,
                Price = recipe.Price,
                Ingredients= recipe.Ingredients,
                Available = recipe.Available,
                Quantity = recipe.Quantity,
            };
        }

        public async Task AddRecipe(CreateRecipeRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var recipe = new Recipe()
            {
                Name = request.Name,
                Price = request.Price,
                Ingredients= request.Ingredients,
                Available = request.Available,
                Quantity = request.Quantity,
            };

            await _recipeRepository.AddAsync(recipe);

            await scope.SaveAsync();
            await scope.CommitAsync();


        }

        public async Task UpdateRecipe(long Id, CreateRecipeRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var recipe = await _recipeRepository.GetRecipeByIdAsync(Id);

            if (recipe == null)
            {
                throw new Exception($"Cannot find recipe with Id {Id}");
            }

            recipe.Name = request.Name;
            recipe.Price = request.Price;
            recipe.Available = request.Available;
            recipe.Ingredients = request.Ingredients;
            recipe.Quantity= request.Quantity;

            await _recipeRepository.UpdateAsync(recipe);

            await scope.SaveAsync();
            await scope.CommitAsync();
        }

        public async Task<bool> DeleteRecipe(long? id)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            _recipeRepository.Delete(recipe);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return true;
        }
    }
}
