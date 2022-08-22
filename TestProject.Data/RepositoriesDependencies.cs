using Microsoft.Extensions.DependencyInjection;
using TestProject.Data.Entities;
using TestProject.Data.Repositories;
using TestProject.Data.Repositories.Interfaces;

namespace TestProject.Data
{
    public static class RepositoriesDependencies
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ZipCoContext>();
            services.AddScoped<IRepository<Account>, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}