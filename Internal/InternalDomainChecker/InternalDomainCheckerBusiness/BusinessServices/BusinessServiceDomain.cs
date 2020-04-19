using AutoMapper;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;
using System;
using System.Threading.Tasks;

namespace InternalDomainCheckerBusiness.BusinessServices
{
    public class BusinessServiceDomain : IBusinessServiceDomain
    {
        private readonly IMapper _iMapper;
        private readonly IDataServiceDomain _iDataServiceDomain;
        private readonly IDataServiceNetwork _iDataServiceNetwork;

        public BusinessServiceDomain(IMapper iMapper, IDataServiceDomain iDataServiceDomain, IDataServiceNetwork iDataServiceNetwork)
        {
            _iMapper = iMapper;
            _iDataServiceDomain = iDataServiceDomain;
            _iDataServiceNetwork = iDataServiceNetwork;
        }

        public async Task<Domain> Create(int orderId, string domain)
        {
            var entityDomain = new EntityDomain
            {
                OrderId = orderId,
                DomainName = domain
            };
            entityDomain.DomainId = await _iDataServiceDomain.Create(entityDomain);
            return _iMapper.Map<Domain>(entityDomain);
        }

        public bool ValidDomain(string domainName)
        {
            if (Uri.CheckHostName(domainName) != UriHostNameType.Unknown)
                return _iDataServiceNetwork.DomainExists(domainName);
            else
                return false;
        }
    }
}
