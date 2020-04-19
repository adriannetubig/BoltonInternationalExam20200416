using InternalDomainCheckerBusiness.Entities;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.DataInterfaces
{
    public interface IDataServiceDomain
    {
        Task<int> Create(EntityDomain entityDomain);
    }
}
