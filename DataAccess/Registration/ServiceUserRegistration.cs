using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Registration
{
    public static class ServiceUserRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
