using AutoMapper;
using InternalVirusTotalIntegrationBusiness.Entities;
using InternalVirusTotalIntegrationBusiness.Models;

namespace InternalVirusTotalIntegrationApi.Helper
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<EntityIpScan, IpScan>().ReverseMap();
                mc.CreateMap<EntityAttributes, Attributes>().ReverseMap();
                mc.CreateMap<EntityLinks, Links>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
