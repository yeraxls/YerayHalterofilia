using YerayHalterofilia.Services;

namespace YerayHalterofilia
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddTransient<ITypeLiftingServices, TypeLiftingServices>();

            return services;
        }
    }
}
