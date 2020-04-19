using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessInterfaces
{
    public interface IBusinessServiceOpenPort
    {
        Task<List<int>> CheckOpenPorts(DomainIpAddress domainIpAddress);
    }
}
