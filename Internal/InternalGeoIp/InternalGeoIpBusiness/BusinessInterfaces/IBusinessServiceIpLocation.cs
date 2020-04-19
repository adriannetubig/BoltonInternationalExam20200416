using InternalGeoIpBusiness.Models;
using System.Threading.Tasks;

namespace InternalGeoIpBusiness.BusinessInterfaces
{
    public interface IBusinessServiceIpLocation
    {
        Task<IpLocation> Read(string ipAddress);
    }
}
