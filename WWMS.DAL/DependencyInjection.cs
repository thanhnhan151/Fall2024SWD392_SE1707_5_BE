using Microsoft.Extensions.DependencyInjection;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDALServices(
            this IServiceCollection services)
        {
            //TODO: register any services used DI

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
