using ExternalSiteInvestigationApi.Interfaces;
using ExternalSiteInvestigationBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationApi.Controllers.V1
{
    public class SiteInvestigationRequestsController : BaseV1Controller
    {
        private readonly IAppServiceSiteInvestigationRequest _iAppServiceSiteInvestigationRequest;

        public SiteInvestigationRequestsController(IAppServiceSiteInvestigationRequest iAppServiceSiteInvestigationRequest)
        {
            _iAppServiceSiteInvestigationRequest = iAppServiceSiteInvestigationRequest;
        }

        [HttpPut]
        public async Task<IActionResult> Create(SiteInvestigationRequest siteInvestigationRequest, CancellationToken cancellationToken)
        {
            return await _iAppServiceSiteInvestigationRequest.Create(siteInvestigationRequest, cancellationToken);
        }
    }
}