using InternalGeoIpBusiness.Entities;
using System.Threading.Tasks;

namespace InternalGeoIpBusiness.DataInterfaces
{
    public interface IDataServiceIpLocation
    {
        Task<EntityIpLocation> Read(string ipAddress);
    }
}
