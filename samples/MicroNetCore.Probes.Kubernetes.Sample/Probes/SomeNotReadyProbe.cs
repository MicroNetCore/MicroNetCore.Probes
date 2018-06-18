using System.Threading.Tasks;

namespace MicroNetCore.Probes.Kubernetes.Sample.Probes
{
    public sealed class SomeNotReadyProbe : IReadinessProbe
    {
        public Task<bool> ProbeAsync()
        {
            return Task.FromResult(false);
        }
    }
}