using InternalDomainCheckerBusiness.Entities;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.DataInterfaces
{
    public interface IDataServiceOpenPort
    {
        Task Create(EntityOpenPort entityOpenPort);
    }
}
