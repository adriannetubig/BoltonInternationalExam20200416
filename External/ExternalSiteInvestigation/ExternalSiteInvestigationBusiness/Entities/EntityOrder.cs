using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExternalSiteInvestigationBusiness.Entities
{
    //Assuming that this might connect to the database
    [Table("Order")]
    public class EntityOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
    }
}
