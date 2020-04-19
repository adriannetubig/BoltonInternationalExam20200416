using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace InternalDomainCheckerApi.Controllers.V1
{
    public class DomainsController : BaseV1Controller
    {
        private readonly IBusinessServiceDomain _iBusinessServiceDomain;
        private readonly IBusinessServiceDomainIpAddress _iBusinessServiceDomainIpAddress;
        private readonly IBusinessServiceOpenPort _iBusinessServiceOpenPort;

        public DomainsController(IBusinessServiceDomain iBusinessServiceDomain, IBusinessServiceDomainIpAddress iBusinessServiceDomainIpAddress,
            IBusinessServiceOpenPort iBusinessServiceOpenPort)
        {
            _iBusinessServiceDomain = iBusinessServiceDomain;
            _iBusinessServiceDomainIpAddress = iBusinessServiceDomainIpAddress;
            _iBusinessServiceOpenPort = iBusinessServiceOpenPort;
        }

        [HttpPut]
        public async Task<IActionResult> Create(Domain domain)
        {
            //ToDo: return a more detailed response.
            //ToDo: create app service
            domain = await _iBusinessServiceDomain.Create(domain);
            var domainIpAddresses = await _iBusinessServiceDomainIpAddress.RetrieveIpAddressOfDomain(domain);
            foreach (var domainIpAddress in domainIpAddresses)
            {
                var openPorts = await _iBusinessServiceOpenPort.CheckOpenPorts(domainIpAddress);
            }

            //Todo: Below code is a cross cutting concern
            return new ObjectResult(domain)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}