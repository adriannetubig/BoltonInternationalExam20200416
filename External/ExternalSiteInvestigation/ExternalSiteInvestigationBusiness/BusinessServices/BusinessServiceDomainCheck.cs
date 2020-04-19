using AutoMapper;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessServices
{
    public class BusinessServiceDomainCheck : IBusinessServiceDomainCheck
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceDomainCheck _iDataServiceDomainCheck;

        public BusinessServiceDomainCheck(IMapper iMapper, IDataServiceDomainCheck iDataServiceDomainCheck)
        {
            _iMapper = iMapper;
            _iDataServiceDomainCheck = iDataServiceDomainCheck;
        }

        public async Task<DomainCheck> Read(int orderId, string domainName, CancellationToken cancellationToken)
        {
            var entityDomainCheck = await _iDataServiceDomainCheck.Read(orderId, domainName, cancellationToken);
            return _iMapper.Map<DomainCheck>(entityDomainCheck);
        }
    }
}
