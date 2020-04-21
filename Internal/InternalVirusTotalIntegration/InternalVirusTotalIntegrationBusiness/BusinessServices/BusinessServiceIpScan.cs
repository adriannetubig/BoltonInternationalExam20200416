using AutoMapper;
using InternalVirusTotalIntegrationBusiness.BusinessInterfaces;
using InternalVirusTotalIntegrationBusiness.DataInterfaces;
using InternalVirusTotalIntegrationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InternalVirusTotalIntegrationBusiness.BusinessServices
{
    public class BusinessServiceIpScan : IBusinessServiceIpScan
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceIpScan _iDataServiceIpScan;
        public BusinessServiceIpScan(IMapper iMapper, IDataServiceIpScan iDataServiceIpScan)
        {
            _iMapper = iMapper;
            _iDataServiceIpScan = iDataServiceIpScan;
        }

        public async Task<IpScan> Read(string ipAddress, CancellationToken cancellationToken)
        {
            var entityDomainCheck = await _iDataServiceIpScan.Read(ipAddress, cancellationToken);
            return _iMapper.Map<IpScan>(entityDomainCheck.data);
        }
    }
}
