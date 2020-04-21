using InternalVirusTotalIntegrationBusiness.BusinessInterfaces;
using InternalVirusTotalIntegrationBusiness.BusinessServices;
using InternalVirusTotalIntegrationBusiness.DataInterfaces;
using InternalVirusTotalIntegrationHttpClientData.DataServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InternalVirusTotalIntegrationApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string virusTotalUrl, string virusTotalApiKey)
        {
            services.AddScoped<IDataServiceIpScan>(a => new DataServiceIpScan(virusTotalUrl, virusTotalApiKey));
            services.AddScoped<IBusinessServiceIpScan, BusinessServiceIpScan>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Virus Total Integration", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
