using System.Collections.Generic;

namespace ExternalSiteInvestigationBusiness.Models
{
    public class IpAddressCheck
    {
        public string IpAddress { get; set; }
        public List<int> Ports { get; set; }
    }
}
