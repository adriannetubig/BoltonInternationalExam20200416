using System.ComponentModel.DataAnnotations;

namespace ExternalSiteInvestigationBusiness.Models
{
    public class SiteInvestigationRequest
    {
        [Required, MaxLength(50), MinLength(4)]
        public string CustomerName { get; set; }
    }
}
