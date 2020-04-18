using AutoMapper;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Entities;
using ExternalSiteInvestigationBusiness.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessServices
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

        public async Task<Order> Create(Order order, CancellationToken cancellationToken)
        {
            var entityOrder = _iMapper.Map<EntityOrder>(order);
            entityOrder = await _iDataServiceOrder.Create(entityOrder, cancellationToken);
            return _iMapper.Map<Order>(entityOrder);
        }
    }
}
