using ApplicationServices.RepositoryInterfaces;
using ApplicationServices.Services.Roles;
using ApplicationServices.Services.Users;
using Microsoft.Extensions.DependencyInjection;
namespace ApplicationServices
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

        }
    }
}
