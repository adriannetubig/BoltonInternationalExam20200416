using Microsoft.AspNetCore.Mvc;

namespace InternalOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}