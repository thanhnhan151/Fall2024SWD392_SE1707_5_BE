using Microsoft.Extensions.DependencyInjection;
using WWMS.BAL.Mappings;
using WWMS.DAL;

namespace WWMS.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            services.ConfigureDALServices();

            services.AddAutoMapper(typeof(MappingProfiles));
            //TODO: register any services used DI

            return services;
        }
    }
}
