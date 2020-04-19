using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExternalSiteInvestigationBusiness.Entities
{
    //Assuming that this might connect to the database
    [Table("IpAddressCheck")]
    public class EntityIpAddressCheck
    {
        public string IpAddress { get; set; }
        public List<int> Ports { get; set; }
    }
}
