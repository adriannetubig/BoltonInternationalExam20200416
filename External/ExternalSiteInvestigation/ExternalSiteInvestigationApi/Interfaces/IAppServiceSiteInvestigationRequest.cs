using ExternalSiteInvestigationBusiness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationApi.Interfaces
{
    public interface IAppServiceSiteInvestigationRequest
    {
        Task<IActionResult> Create(SiteInvestigationRequest siteInvestigationRequest, CancellationToken cancellationToken);
    }
}
