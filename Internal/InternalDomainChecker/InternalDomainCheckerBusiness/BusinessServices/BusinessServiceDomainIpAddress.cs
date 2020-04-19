using AutoMapper;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceDomainIpAddress : IBusinessServiceDomainIpAddress
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceDomainIpAddress _iDataServiceDomainIpAddress;
        private readonly IDataServiceNetwork _iDataServiceNetwork;

        public BusinessServiceDomainIpAddress(IMapper iMapper, IDataServiceDomainIpAddress iDataServiceDomainIpAddress, IDataServiceNetwork iDataServiceNetwork)
        {
            _iMapper = iMapper;
            _iDataServiceDomainIpAddress = iDataServiceDomainIpAddress;
            _iDataServiceNetwork = iDataServiceNetwork;
        }

        public async Task<List<DomainIpAddress>> RetrieveIpAddressOfDomain(Domain domain)
        {
            var domainIpAddresses = new List<DomainIpAddress>();
            var ipAddresses = _iDataServiceNetwork.RetrieveIpAddress(domain.DomainName);
            foreach (var ipAddress in ipAddresses)
            {
                var entityDomainIpAddress = new EntityDomainIpAddress
                {
                    DomainId = domain.DomainId,
                    IpAddress = ipAddress.ToString()
                };
                entityDomainIpAddress.DomainIpAddressId = await _iDataServiceDomainIpAddress.Create(entityDomainIpAddress);

                domainIpAddresses.Add(_iMapper.Map<DomainIpAddress>(entityDomainIpAddress));
            }

            return domainIpAddresses;
        }
    }
}
