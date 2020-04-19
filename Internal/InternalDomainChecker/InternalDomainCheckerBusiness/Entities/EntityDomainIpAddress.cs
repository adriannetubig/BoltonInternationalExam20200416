using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalDomainCheckerBusiness.Entities
{
    [Table("DomainIpAddress")]
    public class EntityDomainIpAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int DomainIpAddressId { get; set; }
        public int DomainId { get; set; }
        public string IpAddress { get; set; }
    }
}
