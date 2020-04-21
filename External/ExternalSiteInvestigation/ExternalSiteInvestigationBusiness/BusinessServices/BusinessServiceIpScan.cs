using AutoMapper;
using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationBusiness.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ExternalSiteInvestigationBusiness.BusinessServices
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
            var entityIpScan = await _iDataServiceIpScan.Read(ipAddress, cancellationToken);
            return _iMapper.Map<IpScan>(entityIpScan);
        }
    }
}
