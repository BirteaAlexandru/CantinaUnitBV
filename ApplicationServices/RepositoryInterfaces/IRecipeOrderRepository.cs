using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IRecipeOrderRepository : IRepository<RecipesOrder>
    {
        Task<ICollection<RecipesOrder>> GetRecipeOrdersAsync();
        Task<RecipesOrder> GetRecipeOrderByIdAsync(long? id, bool isTracked = false);
    }
}
