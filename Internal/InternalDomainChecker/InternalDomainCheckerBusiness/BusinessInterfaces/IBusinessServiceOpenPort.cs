using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessInterfaces
{
    public interface IBusinessServiceOpenPort
    {
        List<int> CheckOpenPorts(DomainIpAddress domainIpAddress);
    }
}
