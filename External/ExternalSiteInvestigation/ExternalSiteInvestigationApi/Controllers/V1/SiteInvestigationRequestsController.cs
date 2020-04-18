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
        private readonly IBusinessServiceOrder _iBusinessServiceOrder;

        public SiteInvestigationRequestsController(IBusinessServiceOrder iBusinessServiceOrder)
        {
            _iBusinessServiceOrder = iBusinessServiceOrder;
        }

        [HttpPut]
        public async Task<IActionResult> CreateAsync(SiteInvestigationRequest siteInvestigationRequest, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = siteInvestigationRequest.CustomerName
            };

            var createdOrder = await _iBusinessServiceOrder.Create(order, cancellationToken);//ToDo: This should be in App Service

            //Todo: Below code is a cross cutting concern
            return new ObjectResult(createdOrder)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }
    }
}