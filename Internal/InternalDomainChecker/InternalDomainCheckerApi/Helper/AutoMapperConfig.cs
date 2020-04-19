using AutoMapper;
using InternalDomainCheckerBusiness.Entities;
using InternalDomainCheckerBusiness.Models;

namespace InternalDomainCheckerApi.Helper
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<EntityDomain, Domain>().ReverseMap();
                mc.CreateMap<EntityDomainIpAddress, DomainIpAddress>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
