using Microsoft.Extensions.DependencyInjection;

namespace MicroNetCore.Probes.Kubernetes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLivenessProbe<TProbe>(this IServiceCollection services)
            where TProbe : class, ILivenessProbe
        {
            services.AddSingleton<ILivenessProbe, TProbe>();

            return services;
        }

        public static IServiceCollection AddReadinessProbe<TProbe>(this IServiceCollection services)
            where TProbe : class, IReadinessProbe
        {
            services.AddSingleton<IReadinessProbe, TProbe>();

            return services;
        }
    }
}