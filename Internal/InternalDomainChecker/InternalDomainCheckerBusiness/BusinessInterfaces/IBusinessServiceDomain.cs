using InternalDomainCheckerBusiness.Models;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessInterfaces
{
    public interface IBusinessServiceDomain
    {
        Task<Domain> Create(int orderId, string domain);
        bool ValidDomain(string domainName);
    }
}
