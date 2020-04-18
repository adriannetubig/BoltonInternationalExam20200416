using AutoMapper;
using InternalOrderBusiness.BusinessInterfaces;
using InternalOrderBusiness.DataInterfaces;
using InternalOrderBusiness.Entities;
using InternalOrderBusiness.Models;

namespace InternalOrderBusiness.BusinessServices
{
    public class BusinessServiceOrder: IBusinessServiceOrder
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceOrder _iDataServiceOrder;

        public BusinessServiceOrder(IMapper iMapper, IDataServiceOrder iDataServiceOrder)
        {
            _iMapper = iMapper;
            _iDataServiceOrder = iDataServiceOrder;
        }

        public Order Create(Order order)
        {
            var entityOrder = _iMapper.Map<EntityOrder>(order);
            entityOrder.OrderId = _iDataServiceOrder.Create(entityOrder);
            return _iMapper.Map<Order>(entityOrder);
        }
    }
}
