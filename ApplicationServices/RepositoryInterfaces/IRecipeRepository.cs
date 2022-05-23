using ApplicationServices.RepositoryInterfaces.Generics;
using Domain;
using Domain.Search;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IPartialCollection<Recipe>> GetRecipesAsync(SearchArgs searchArgs);
        Task<Recipe> GetRecipeByIdAsync(long? id, bool isTracked = false);
    }
}
