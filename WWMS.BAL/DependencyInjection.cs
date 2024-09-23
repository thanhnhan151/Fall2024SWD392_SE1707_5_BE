﻿using Microsoft.Extensions.DependencyInjection;
using WWMS.BAL.Mappings;

namespace WWMS.BAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureBALServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            return services;
        }
    }
}