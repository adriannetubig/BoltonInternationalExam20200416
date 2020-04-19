using InternalDomainCheckerApi.Interfaces;
using InternalDomainCheckerApi.Services;
using InternalDomainCheckerBusiness.BusinessInterfaces;
using InternalDomainCheckerBusiness.BusinessServices;
using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerEFData;
using InternalDomainCheckerEFData.DataServices;
using InternalDomainCheckerSystemNetData.DataService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InternalDomainCheckerApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, int[] toCheckPorts, string connectionString)
        {
            services.AddDbContext<InternalDomainCheckerContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDataServiceDomain, DataServiceDomain>();
            services.AddScoped<IDataServiceNetwork, DataServiceNetwork>();
            services.AddScoped<IDataServiceDomainIpAddress, DataServiceDomainIpAddress>();
            services.AddScoped<IDataServiceOpenPort, DataServiceOpenPort>();

            services.AddScoped<IBusinessServiceDomain, BusinessServiceDomain>();
            services.AddScoped<IBusinessServiceDomainIpAddress, BusinessServiceDomainIpAddress>();
            services.AddScoped<IBusinessServiceOpenPort>(a => new BusinessServiceOpenPort(a.GetService<IDataServiceNetwork>(), a.GetService<IDataServiceOpenPort>(), toCheckPorts));

            services.AddScoped<IAppServiceDomain, AppServiceDomain>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Domain Checker", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
