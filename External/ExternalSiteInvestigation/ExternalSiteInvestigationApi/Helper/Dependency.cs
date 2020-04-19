using ExternalSiteInvestigationBusiness.BusinessInterfaces;
using ExternalSiteInvestigationBusiness.BusinessServices;
using ExternalSiteInvestigationBusiness.DataInterfaces;
using ExternalSiteInvestigationHttpClientDataService.DataServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExternalSiteInvestigationApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string internalOrderUrl)
        {
            services.AddScoped<IDataServiceOrder>(a => new DataServiceOrder(internalOrderUrl));
            services.AddScoped<IBusinessServiceOrder, BusinessServiceOrder>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "External Site Investigator", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
