using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<ICollection<Recipe>> GetRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(long? id, bool isTracked = false);
    }
}
