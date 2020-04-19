using InternalDomainCheckerApi.Dto;
using InternalDomainCheckerApi.Interfaces;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InternalDomainCheckerApi.Services
{
    public class AppServiceDomain: IAppServiceDomain
    {
        private readonly IBusinessServiceDomain _iBusinessServiceDomain;
        private readonly IBusinessServiceDomainIpAddress _iBusinessServiceDomainIpAddress;
        private readonly IBusinessServiceOpenPort _iBusinessServiceOpenPort;
        public AppServiceDomain(IBusinessServiceDomain iBusinessServiceDomain, IBusinessServiceDomainIpAddress iBusinessServiceDomainIpAddress,
            IBusinessServiceOpenPort iBusinessServiceOpenPort)
        {
            _iBusinessServiceDomain = iBusinessServiceDomain;
            _iBusinessServiceDomainIpAddress = iBusinessServiceDomainIpAddress;
            _iBusinessServiceOpenPort = iBusinessServiceOpenPort;
        }

        public async Task<IActionResult> DomainCheck(int orderId, string domainName)
        {
            var domain = await _iBusinessServiceDomain.Create(orderId, domainName);

            if (_iBusinessServiceDomain.ValidDomain(domainName))
            {
                var checkResult = new DtoDomainCheck
                {
                    Domain = domain.DomainName,
                    IpAddresses = new List<DtoIpAddress>()
                };

                var domainIpAddresses = await _iBusinessServiceDomainIpAddress.RetrieveIpAddressOfDomain(domain);
                foreach (var domainIpAddress in domainIpAddresses)
                {
                    var openPorts = _iBusinessServiceOpenPort.CheckOpenPorts(domainIpAddress);
                    var dtoIpAddress = new DtoIpAddress()
                    {
                        IpAddress = domainIpAddress.IpAddress,
                        Ports = openPorts
                    };

                    checkResult.IpAddresses.Add(dtoIpAddress);
                }

                return new ObjectResult(checkResult)
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
