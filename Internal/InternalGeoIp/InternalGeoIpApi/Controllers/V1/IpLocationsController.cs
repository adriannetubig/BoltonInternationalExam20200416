using InternalGeoIpBusiness.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace InternalGeoIpApi.Controllers.V1
{
    public class IpLocationsController: BaseV1Controller
    {
        private readonly IBusinessServiceIpLocation _iBusinessServiceIpLocation;
        public IpLocationsController(IBusinessServiceIpLocation iBusinessServiceIpLocation)
        {
            _iBusinessServiceIpLocation = iBusinessServiceIpLocation;
        }

        [HttpGet("{ipAddress}")]
        public async Task<IActionResult> Read(string ipAddress)
        {
            var ipLocation = await _iBusinessServiceIpLocation.Read(ipAddress);
            //ToDo: This should be an App Logic

            if(ipLocation != null)
            {
                return new ObjectResult(ipLocation)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }
        }
    }
}