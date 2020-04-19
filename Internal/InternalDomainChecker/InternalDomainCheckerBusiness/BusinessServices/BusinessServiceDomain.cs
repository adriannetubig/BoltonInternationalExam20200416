using AutoMapper;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceDomain : IBusinessServiceDomain
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceDomain _iDataServiceDomain;

        public BusinessServiceDomain(IMapper iMapper, IDataServiceDomain iDataServiceDomain)
        {
            _iMapper = iMapper;
            _iDataServiceDomain = iDataServiceDomain;
        }

        public async Task<Domain> Create(Domain domain)
        {
            var entityDomain = _iMapper.Map<EntityDomain>(domain);
            domain.DomainId = await _iDataServiceDomain.Create(entityDomain);
            return domain;
        }
    }
}
