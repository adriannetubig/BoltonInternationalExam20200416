using ExternalSiteInvestigationApi.Dto;
using ExternalSiteInvestigationApi.Interfaces;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationApi.Services
{
    public class AppServiceSiteInvestigationRequest: IAppServiceSiteInvestigationRequest
    {
        private readonly IBusinessServiceDomainCheck _iBusinessServiceDomainCheck;
        private readonly IBusinessServiceIpScan _iBusinessServiceIpScan;
        private readonly IBusinessServiceOrder _iBusinessServiceOrder;

        public AppServiceSiteInvestigationRequest(IBusinessServiceDomainCheck iBusinessServiceDomainCheck, IBusinessServiceIpScan iBusinessServiceIpScan, IBusinessServiceOrder iBusinessServiceOrder)
        {
            _iBusinessServiceDomainCheck = iBusinessServiceDomainCheck;
            _iBusinessServiceIpScan = iBusinessServiceIpScan;
            _iBusinessServiceOrder = iBusinessServiceOrder;
        }
        public async Task<IActionResult> Create(SiteInvestigationRequest siteInvestigationRequest, CancellationToken cancellationToken)
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

                foreach(var ipAddress in domainCheck.IpAddresses)
                    ipAddress.IpScan = await _iBusinessServiceIpScan.Read(ipAddress.IpAddress, cancellationToken);
            }



            //Todo: Below code is a cross cutting concern
            return new ObjectResult(investigationResult)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}
