using InternalDomainCheckerBusiness.Entities;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.DataInterfaces
{
    public interface IDataServiceDomainIpAddress
    {
        Task<int> Create(EntityDomainIpAddress entityDomainIpAddress);
    }
}
