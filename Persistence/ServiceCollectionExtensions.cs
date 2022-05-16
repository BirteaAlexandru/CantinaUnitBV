using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.RepositoryInterfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.Generics;

namespace Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CantinaBvContext>(opt => opt.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
