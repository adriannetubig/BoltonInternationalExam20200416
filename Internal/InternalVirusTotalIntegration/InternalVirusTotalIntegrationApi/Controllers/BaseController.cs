using Microsoft.AspNetCore.Mvc;

namespace InternalVirusTotalIntegrationApi.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}