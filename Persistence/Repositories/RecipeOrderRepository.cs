using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.RepositoryInterfaces;

namespace Persistence.Repositories
{
    internal class RecipeOrderRepository : Repository<RecipesOrder>, IRecipeOrderRepository
    {
        public RecipeOrderRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<ICollection<RecipesOrder>> GetRecipeOrdersAsync()
        {
            var recipeOrders = await GetAllAsync();

            return recipeOrders;
        }

        public async Task<RecipesOrder> GetRecipeOrderByIdAsync(long? id, bool isTracked = false)
        {
            var recipeOrders = await GetByIdAsync(id);

            return recipeOrders;
        }
    }
}
