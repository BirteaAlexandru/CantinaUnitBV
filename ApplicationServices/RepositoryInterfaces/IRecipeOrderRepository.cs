using Domain;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRecipeOrderRepository : IRepository<RecipesOrder>
    {
        Task<ICollection<RecipesOrder>> GetRecipeOrdersAsync();
        Task<RecipesOrder> GetRecipeOrderByIdAsync(long? id, bool isTracked = false);
    }
}
