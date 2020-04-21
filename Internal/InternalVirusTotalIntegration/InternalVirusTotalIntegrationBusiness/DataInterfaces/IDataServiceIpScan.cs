using InternalVirusTotalIntegrationBusiness.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace InternalVirusTotalIntegrationBusiness.DataInterfaces
{
    public interface IDataServiceIpScan
    {
        Task<EntityVirusTotalResult> Read(string ipAddress, CancellationToken cancellationToken);
    }
}
