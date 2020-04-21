using InternalVirusTotalIntegrationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InternalVirusTotalIntegrationBusiness.BusinessInterfaces
{
    public interface IBusinessServiceIpScan
    {
        Task<IpScan> Read(string ipAddress, CancellationToken cancellationToken);
    }
}
