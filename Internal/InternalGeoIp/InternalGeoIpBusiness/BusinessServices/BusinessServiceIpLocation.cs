using AutoMapper;
using InternalGeoIpBusiness.BusinessInterfaces;
using InternalGeoIpBusiness.DataInterfaces;
using InternalGeoIpBusiness.Models;
using System.Threading.Tasks;

namespace InternalGeoIpBusiness.BusinessServices
{
    public class BusinessServiceIpLocation : IBusinessServiceIpLocation
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceIpLocation _iDataServiceIpLocation;

        public BusinessServiceIpLocation(IMapper iMapper, IDataServiceIpLocation iDataServiceIpLocation)
        {
            _iMapper = iMapper;
            _iDataServiceIpLocation = iDataServiceIpLocation;
        }
        public async Task<IpLocation> Read(string ipAddress)
        {
            var entityIpLocation = await _iDataServiceIpLocation.Read(ipAddress);
            return _iMapper.Map<IpLocation>(entityIpLocation);
        }
    }
}
