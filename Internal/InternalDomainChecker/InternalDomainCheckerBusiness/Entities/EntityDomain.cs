using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalDomainCheckerBusiness.Entities
{
    [Table("Domain")]
    public class EntityDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public int OrderId { get; set; }
    }
}
