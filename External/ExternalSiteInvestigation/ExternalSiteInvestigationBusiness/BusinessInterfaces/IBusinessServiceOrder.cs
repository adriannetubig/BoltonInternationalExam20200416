using ExternalSiteInvestigationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessInterfaces
{
    public interface IBusinessServiceOrder
    {
        Task<Order> Create(Order order, CancellationToken cancellationToken);
    }
}
