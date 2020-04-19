using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalDomainCheckerBusiness.Entities
{
    [Table("OpenPort")]
    public class EntityOpenPort
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int OpenPortId { get; set; }
        public int DomainIpAddressId { get; set; }
        public int Port { get; set; }
    }
}
