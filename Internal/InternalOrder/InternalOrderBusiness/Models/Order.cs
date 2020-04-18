using System.ComponentModel.DataAnnotations;

namespace InternalOrderBusiness.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; }
    }

}
