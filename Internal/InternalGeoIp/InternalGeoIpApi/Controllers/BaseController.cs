using Microsoft.AspNetCore.Mvc;

namespace InternalGeoIpApi.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}