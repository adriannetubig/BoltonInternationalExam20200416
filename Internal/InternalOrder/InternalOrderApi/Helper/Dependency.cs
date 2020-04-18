using InternalOrderBusiness.BusinessInterfaces;
using InternalOrderBusiness.BusinessServices;
using InternalOrderBusiness.DataInterfaces;
using InternalOrderEFData;
using InternalOrderEFData.DataServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternalOrderApi.Helper
{
    public static class Dependency
    {
        public static void SetDependency(ref IServiceCollection services, string connectionString)
        {
            services.AddDbContext<InternalOrderContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDataServiceOrder, DataServiceOrder>();
            services.AddScoped<IBusinessServiceOrder, BusinessServiceOrder>();
        }
    }
}
