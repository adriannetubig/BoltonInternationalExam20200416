using ExternalSiteInvestigationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessInterfaces
{
    public interface IBusinessServiceDomainCheck
    {
        Task<DomainCheck> Read(int orderId, string domainName, CancellationToken cancellationToken);
    }
}
