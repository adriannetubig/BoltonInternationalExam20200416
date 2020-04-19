using AutoMapper;
using InternalGeoIpBusiness.Entities;
using InternalGeoIpBusiness.Models;

namespace InternalGeoIpApi.Helper
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<EntityIpLocation, IpLocation>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
