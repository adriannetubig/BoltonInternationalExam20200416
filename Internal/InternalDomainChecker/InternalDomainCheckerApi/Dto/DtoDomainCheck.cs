using System.Collections.Generic;

namespace InternalDomainCheckerApi.Dto
{
    public class DtoDomainCheck
    {
        public string Domain { get; set; }
        public List<DtoIpAddress> IpAddresses { get; set; }
    }
}
