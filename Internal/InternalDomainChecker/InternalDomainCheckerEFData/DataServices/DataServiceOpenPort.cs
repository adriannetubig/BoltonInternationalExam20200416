using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InternalDomainCheckerEFData.DataServices
{
    public class DataServiceOpenPort : IDataServiceOpenPort
    {
        private readonly DbContextOptions<InternalDomainCheckerContext> _dbContextOptions;

        public DataServiceOpenPort(DbContextOptions<InternalDomainCheckerContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task Create(EntityOpenPort entityOpenPort)
        {
            using (var context = new InternalDomainCheckerContext(_dbContextOptions))
            {
                context.OpenPorts.Add(entityOpenPort);
                await context.SaveChangesAsync();
            }
        }
    }
}
