using ExternalSiteInvestigationBusiness.Interfaces;
using ExternalSiteInvestigationBusiness.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExternalSiteInvestigationApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string internalOrderUrl)
        {
            services.AddScoped<IBusinessServiceOrder>(a => new BusinessServiceOrder(internalOrderUrl));

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Order", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
