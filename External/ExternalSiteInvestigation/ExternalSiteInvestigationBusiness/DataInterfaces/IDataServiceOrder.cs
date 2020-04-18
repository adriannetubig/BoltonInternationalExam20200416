using ExternalSiteInvestigationBusiness.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.DataInterfaces
{
    public interface IDataServiceOrder
    {
        Task<EntityOrder> Create(EntityOrder entityOrder, CancellationToken cancellationToken);
    }
}
