using InternalOrderBusiness.Models;

namespace InternalOrderBusiness.BusinessInterfaces
{
    public interface IBusinessServiceOrder
    {
        Order Create(Order order);
    }
}
