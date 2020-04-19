using ExternalSiteInvestigationBusiness.Models;
using System.Collections.Generic;

namespace ExternalSiteInvestigationApi.Dto
{
    public class InvestigationResult
    {
        public bool IsDomainValid { get; set; }
        public string Domain { get; set; }
        public List<IpAddressCheck> IpAddresses { get;set; }
        
    }
}
