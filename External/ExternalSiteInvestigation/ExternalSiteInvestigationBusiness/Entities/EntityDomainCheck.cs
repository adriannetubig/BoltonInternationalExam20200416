using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExternalSiteInvestigationBusiness.Entities
{
    //Assuming that this might connect to the database
    [Table("DomainCheck")]
    public class EntityDomainCheck
    {
        public string Domain { get; set; }
        public List<EntityIpAddressCheck> IpAddresses { get; set; }
    }
}
