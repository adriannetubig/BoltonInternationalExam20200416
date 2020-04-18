using System.ComponentModel.DataAnnotations;

namespace InternalOrderBusiness.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required, MaxLength(50), MinLength(4)]
        public string CustomerName { get; set; }
    }

}
