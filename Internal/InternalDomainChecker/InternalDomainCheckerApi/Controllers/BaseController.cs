using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternalDomainCheckerApi.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}