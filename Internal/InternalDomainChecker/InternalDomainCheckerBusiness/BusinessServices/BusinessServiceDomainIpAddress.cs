using AutoMapper;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceDomainIpAddress : IBusinessServiceDomainIpAddress
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceDomainIpAddress _iDataServiceDomainIpAddress;

        public BusinessServiceDomainIpAddress(IMapper iMapper, IDataServiceDomainIpAddress iDataServiceDomainIpAddress)
        {
            _iMapper = iMapper;
            _iDataServiceDomainIpAddress = iDataServiceDomainIpAddress;
        }

        public async Task<List<DomainIpAddress>> RetrieveIpAddressOfDomain(Domain domain)
        {
            var domainIpAddresses = new List<DomainIpAddress>();
            var ipAddresses = await Dns.GetHostAddressesAsync(domain.DomainName); //ToDo: this will not be testable

            foreach(var ipAddress in ipAddresses)
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
