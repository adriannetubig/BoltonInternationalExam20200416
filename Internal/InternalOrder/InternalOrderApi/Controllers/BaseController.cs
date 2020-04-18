using Microsoft.AspNetCore.Mvc;

namespace InternalOrderApi.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}