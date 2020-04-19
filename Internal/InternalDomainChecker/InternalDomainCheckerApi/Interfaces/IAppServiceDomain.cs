using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternalDomainCheckerApi.Interfaces
{
    public interface IAppServiceDomain
    {
        Task<IActionResult> DomainCheck(int orderId, string domainName);
    }
}
