using ExternalSiteInvestigationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessInterfaces
{
    public interface IBusinessServiceIpScan
    {
        Task<IpScan> Read(string ipAddress, CancellationToken cancellationToken);
    }
}
