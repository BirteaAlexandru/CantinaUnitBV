using Domain;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<ICollection<Recipe>> GetRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(long? id, bool isTracked = false);
    }
}
