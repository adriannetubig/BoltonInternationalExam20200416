using Microsoft.AspNetCore.Mvc;

namespace ExternalSiteInvestigationApi.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}