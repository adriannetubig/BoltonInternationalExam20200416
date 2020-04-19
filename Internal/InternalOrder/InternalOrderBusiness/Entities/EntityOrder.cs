using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternalOrderBusiness.Entities
{
    [Table("Order")]
    public class EntityOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
    }
}
