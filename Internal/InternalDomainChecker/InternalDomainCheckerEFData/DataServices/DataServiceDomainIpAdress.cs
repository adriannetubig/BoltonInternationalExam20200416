using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InternalDomainCheckerEFData.DataServices
{
    public class DataServiceDomainIpAddress : IDataServiceDomainIpAddress
    {
        private readonly DbContextOptions<InternalDomainCheckerContext> _dbContextOptions;

        public DataServiceDomainIpAddress(DbContextOptions<InternalDomainCheckerContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task<int> Create(EntityDomainIpAddress entityDomainIpAddress)
        {
            using (var context = new InternalDomainCheckerContext(_dbContextOptions))
            {
                context.DomainIpAddresses.Add(entityDomainIpAddress);
                await context.SaveChangesAsync();
                return entityDomainIpAddress.DomainIpAddressId;
            }
        }
    }
}
