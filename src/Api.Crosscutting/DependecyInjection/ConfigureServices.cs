using Api.Service.Interfaces;
using Api.Service.PasswordHasher;
using Api.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Crosscutting.DependecyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServiceDependecies(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<Hasher, Hasher>();

            return services;
        }
    }
}