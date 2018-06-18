using System.Threading.Tasks;

namespace MicroNetCore.Probes.Kubernetes.Sample.Probes
{
    public sealed class SomeNotAliveProbe : ILivenessProbe
    {
        public Task<bool> ProbeAsync()
        {
            return Task.FromResult(false);
        }
    }
}