using Dix.Business.Interface;
using Dix.Business.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Dix.Business.Registration
{
    public static class ServiceUserLogicRegistration
    {
        public static void AddLogicInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserLogic, UserLogic>();
        }
    }
}
