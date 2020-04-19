using System.Collections.Generic;

namespace InternalDomainCheckerApi.Dto
{
    public class DtoIpAddress
    {
        public string IpAddress { get; set; }
        public List<int> Ports { get; set; }
    }
}
