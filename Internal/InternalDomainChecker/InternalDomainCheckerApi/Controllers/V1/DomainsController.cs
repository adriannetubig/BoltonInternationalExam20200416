using InternalDomainCheckerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace InternalDomainCheckerApi.Controllers.V1
{
    public class DomainsController : BaseV1Controller
    {
        private readonly IAppServiceDomain _iAppServiceDomain;

        public DomainsController(IAppServiceDomain iAppServiceDomain)
        {
            _iAppServiceDomain = iAppServiceDomain;
        }

        [HttpGet("{orderId}/{domainName}")]
        public async Task<IActionResult> Read(int orderId, string domainName)
        {
            return await _iAppServiceDomain.DomainCheck(orderId, domainName);
        }
    }
}