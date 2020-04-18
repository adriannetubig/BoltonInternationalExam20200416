using AutoMapper;
using InternalOrderBusiness.Entities;
using InternalOrderBusiness.Models;

namespace InternalOrderApi.Helper
{
    public static class AutoMapperConfig
    {
        public static IMapper Config()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<EntityOrder, Order>().ReverseMap();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
