using MicroNetCore.Probes.Core;
using Microsoft.AspNetCore.Builder;

namespace MicroNetCore.Probes.Kubernetes.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseKubernetesHttpLivenessEndpoint(this IApplicationBuilder app,
            string path = Paths.Liveness)
        {
            app.UseMiddleware<HttpProbesMiddleware<ILivenessProbe>>(path);

            return app;
        }

        public static IApplicationBuilder UseKubernetesHttpReadinessEndpoint(this IApplicationBuilder app,
            string path = Paths.Readiness)
        {
            app.UseMiddleware<HttpProbesMiddleware<IReadinessProbe>>(path);

            return app;
        }
    }
}