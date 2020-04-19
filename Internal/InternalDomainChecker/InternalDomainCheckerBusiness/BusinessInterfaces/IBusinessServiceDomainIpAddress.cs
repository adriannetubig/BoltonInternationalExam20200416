using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessInterfaces
{
    public interface IBusinessServiceDomainIpAddress
    {
        Task<List<DomainIpAddress>> RetrieveIpAddressOfDomain(Domain domain);
    }
}
