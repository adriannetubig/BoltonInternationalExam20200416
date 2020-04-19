using ExternalSiteInvestigationApi.Dto;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationApi.Controllers.V1
{
    public class SiteInvestigationRequestsController : BaseV1Controller
    {
        private readonly IBusinessServiceDomainCheck _iBusinessServiceDomainCheck;
        private readonly IBusinessServiceOrder _iBusinessServiceOrder;

        public SiteInvestigationRequestsController(IBusinessServiceDomainCheck iBusinessServiceDomainCheck, IBusinessServiceOrder iBusinessServiceOrder)
        {
            _iBusinessServiceDomainCheck = iBusinessServiceDomainCheck;
            _iBusinessServiceOrder = iBusinessServiceOrder;
        }

        [HttpPut]
        public async Task<IActionResult> CreateAsync(SiteInvestigationRequest siteInvestigationRequest, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = siteInvestigationRequest.CustomerName
            };

            var investigationResult = new InvestigationResult
            {
                Domain = siteInvestigationRequest.Domain
            };

            var createdOrder = await _iBusinessServiceOrder.Create(order, cancellationToken);//ToDo: This should be in App Service
            var domainCheck = await _iBusinessServiceDomainCheck.Read(createdOrder.OrderId, siteInvestigationRequest.Domain, cancellationToken);

            if (domainCheck != null)
            {
                investigationResult.IpAddresses = domainCheck.IpAddresses;
                investigationResult.IsDomainValid = true;
            }

            

            //Todo: Below code is a cross cutting concern
            return new ObjectResult(investigationResult)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}