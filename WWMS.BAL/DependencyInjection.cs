using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Mappings;
using WWMS.BAL.Services;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Persistences;

namespace WWMS.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            services.AddDbContext<WineWarehouseDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IWineService, WineService>();

            services.AddScoped<IRoomService, RoomService>();

            services.AddScoped<IWineCategoryService, WineCategoryService>();

            return services;
        }
    }
}
