﻿using YerayHalterofilia.Services;

namespace YerayHalterofilia
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<ITypeLiftingServices, TypeLiftingServices>();
            services.AddScoped<ICountryServices, CountryServices>();
            services.AddScoped<ICompetitorServices, CompetitorServices>();
            services.AddScoped<ILiftingWeightServices, LiftingWeightServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ILoggerSistemService, LoggerSistemService>();

            return services;
        }
    }
}
