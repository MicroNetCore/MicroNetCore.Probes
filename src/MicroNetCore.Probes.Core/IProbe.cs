using System.Threading.Tasks;

namespace MicroNetCore.Probes.Core
{
    public interface IProbe
    {
        Task<bool> ProbeAsync();
    }
}