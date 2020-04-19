using ExternalSiteInvestigationBusiness.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.DataInterfaces
{
    public interface IDataServiceDomainCheck
    {
        Task<EntityDomainCheck> Read(int orderId, string domainName, CancellationToken cancellationToken);
    }
}
