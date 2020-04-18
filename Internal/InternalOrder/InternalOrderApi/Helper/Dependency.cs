using InternalOrderBusiness.BusinessInterfaces;
using InternalOrderBusiness.BusinessServices;
using InternalOrderBusiness.DataInterfaces;
using InternalOrderEFData;
using InternalOrderEFData.DataServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InternalOrderApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string connectionString)
        {
            services.AddDbContext<InternalOrderContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDataServiceOrder, DataServiceOrder>();
            services.AddScoped<IBusinessServiceOrder, BusinessServiceOrder>();

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo { Title = "Internal Order", Version = "v1" }); //ToDo: use this drop down for versioning
            });
        }
    }
}
