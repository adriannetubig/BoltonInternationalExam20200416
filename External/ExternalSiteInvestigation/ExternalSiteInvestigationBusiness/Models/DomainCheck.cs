using System.Collections.Generic;

namespace ExternalSiteInvestigationBusiness.Models
{
    public class DomainCheck
    {
        public string Domain { get; set; }
        public List<IpAddressCheck> IpAddresses { get; set; }
    }
}
