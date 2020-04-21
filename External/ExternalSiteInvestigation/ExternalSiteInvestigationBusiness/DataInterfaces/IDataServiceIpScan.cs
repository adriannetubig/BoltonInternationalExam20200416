using ExternalSiteInvestigationBusiness.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.DataInterfaces
{
    public interface IDataServiceIpScan
    {
        Task<EntityIpScan> Read(string ipAddress, CancellationToken cancellationToken);
    }
}
