using InternalGeoIpBusiness.BusinessInterfaces;
using InternalGeoIpBusiness.BusinessServices;
using InternalGeoIpBusiness.DataInterfaces;
using InternalGeoIpMaxMindData.DataServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InternalGeoIpApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, int accountId, string licenseKey)
        {
            services.AddScoped<IDataServiceIpLocation>(a => new DataServiceIpLocation(accountId, licenseKey));

            services.AddScoped<IBusinessServiceIpLocation, BusinessServiceIpLocation>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Domain Checker", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
