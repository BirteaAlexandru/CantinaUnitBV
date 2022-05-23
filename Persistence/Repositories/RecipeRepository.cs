using Domain;
using Persistence.Context;
using System.Diagnostics.CodeAnalysis;
using ApplicationServices.RepositoryInterfaces;
using Persistence.Repositories.Base;
using ApplicationServices.RepositoryInterfaces.Generics;
using System.Linq.Expressions;
using Domain.Search;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal class RecipeRepository : RepositoryWithSearch<Recipe>, IRecipeRepository
    {
        public RecipeRepository([NotNull] CantinaBvContext context) : base(context)
        {
        }
        public async Task<IPartialCollection<Recipe>> GetRecipesAsync(SearchArgs searchArgs)
        {
            Expression<Func<Recipe, bool>>? predicate = null;

            if (!string.IsNullOrWhiteSpace(searchArgs.SearchText))
            {
                var searchText = RemoveDiacritics(searchArgs.SearchText);

                predicate = p => EF.Functions.Collate(p.Name, "SQL_Latin1_General_CP1_CI_AI").Contains(searchText);
            }

            var sortExpression = string.Equals(searchArgs.SortOption.PropertyName, "Name", StringComparison.InvariantCultureIgnoreCase)
                ? p => p.Name
                : SortExpression(searchArgs, "Id");

            if (predicate == null)
            {
                return await GetAllAsync(searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);
            }

            return await GetAllByAsync(predicate, searchArgs.SortOption.SortOrder, sortExpression, searchArgs.Offset, searchArgs.Limit);

        }

        public async Task<Recipe> GetRecipeByIdAsync(long? id, bool isTracked = false)
        {
            var recipes = await GetByIdAsync(id);

            return recipes;
        }
    }
}
