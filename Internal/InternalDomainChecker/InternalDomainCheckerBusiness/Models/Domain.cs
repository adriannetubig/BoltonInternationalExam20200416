using System.ComponentModel.DataAnnotations;

namespace InternalDomainCheckerBusiness.Models
{
    public class Domain
    {
        public int DomainId { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string DomainName { get; set; }//ToDo: Create code to make sure that only domains are available

        [Required]
        public int OrderId { get; set; }
    }
}
