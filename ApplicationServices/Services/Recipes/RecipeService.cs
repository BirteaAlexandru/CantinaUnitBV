using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using ApplicationServices.Services.Recipes.Response;
using Microsoft.Extensions.Logging;
using Domain;
using ApplicationServices.Services.Recipes.Request;
using Domain.Base;

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
        public async Task<Result<RecipeResponse>> GetRecipeById(long? id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                return Result.Failure<RecipeResponse>($"Cannot find recipe with Id {id}");
            }

            var result= new RecipeResponse
            {
                Name = recipe.Name,
                Price = recipe.Price,
                Ingredients= recipe.Ingredients,
                Available = recipe.Available,
                Quantity = recipe.Quantity,
            };
            
            return Result.Success(result);
        }

        public async Task<Result> AddRecipe(CreateRecipeRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var recipeOrError = Recipe.Create(request.Name, request.Price, request.Ingredients, request.Available, request.Quantity);

            if (recipeOrError.IsFailure)
            {
                return Result.Failure(recipeOrError.Error);
            }

            await _recipeRepository.AddAsync(recipeOrError.Value);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success("Recipe was created successfully");
        }

        public async Task<Result> UpdateRecipe(long Id, CreateRecipeRequest request)
        {
            var scope = await _unitOfWork.CreateScopeAsync();
            var recipe = await _recipeRepository.GetRecipeByIdAsync(Id);

            if (recipe == null)
            {
                throw new Exception($"Cannot find recipe with Id {Id}");
            }

            var recipeOrError = recipe.Update(request.Name, request.Price, request.Ingredients, request.Available, request.Quantity);

            if (recipeOrError.IsFailure)
            {
                return Result.Failure(recipeOrError.Error);
            }

            await _recipeRepository.UpdateAsync(recipe);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success("Recipe was uppdated successfully");
        }

        public async Task<Result> DeleteRecipe(long? id)
        {
            var scope = await _unitOfWork.CreateScopeAsync();

            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return Result.Failure($"Cannot find recipe with Id {id}");
            }
            _recipeRepository.Delete(recipe);

            await scope.SaveAsync();
            await scope.CommitAsync();

            return Result.Success();
        }
    }
}
