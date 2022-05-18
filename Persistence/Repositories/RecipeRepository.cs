using Domain;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using ApplicationServices.RepositoryInterfaces;


namespace Persistence.Repositories
{
    internal class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<ICollection<Recipe>> GetRecipesAsync()
        {
            var recipes = await GetAllAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipeByIdAsync(long? id, bool isTracked = false)
        {
            var recipes = await GetByIdAsync(id);

            return recipes;
        }
    }
}
