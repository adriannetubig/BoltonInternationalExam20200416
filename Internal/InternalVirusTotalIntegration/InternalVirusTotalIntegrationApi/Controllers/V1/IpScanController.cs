using InternalVirusTotalIntegrationBusiness.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace InternalVirusTotalIntegrationApi.Controllers.V1
{
    public class IpScanController: BaseV1Controller
    {
        private readonly IBusinessServiceIpScan _iBusinessServiceIpScan;

        public IpScanController(IBusinessServiceIpScan iBusinessServiceIpScan)
        {
            _iBusinessServiceIpScan = iBusinessServiceIpScan;
        }

        [HttpGet("{ipAddress}")]
        public async Task<IActionResult> Read(string ipAddress, CancellationToken cancellationToken)
        {
            var ipScan = await _iBusinessServiceIpScan.Read(ipAddress, cancellationToken);

            if (ipScan != null)
                return new ObjectResult(ipScan)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            else
                return new ObjectResult(null)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
        }
    }
}