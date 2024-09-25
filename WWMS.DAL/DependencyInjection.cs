using Microsoft.Extensions.DependencyInjection;

namespace WWMS.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDALServices(
            this IServiceCollection services)
        {
            //TODO: register any services used DI         

            return services;
        }
    }
}
