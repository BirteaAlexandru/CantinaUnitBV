using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Recipes;
using ApplicationServices.Services.Roles;
using ApplicationServices.Services.Users;
using Microsoft.Extensions.DependencyInjection;
namespace ApplicationServices
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<Services.Users.IUserService, Services.Users.UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<Services.Orders.IOrderService, Services.Orders.OrderService>();

        }
    }
}
