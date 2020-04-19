using InternalDomainCheckerBusiness.DataInterfaces;
using InternalDomainCheckerBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InternalDomainCheckerEFData.DataServices
{
    public class DataServiceDomain : IDataServiceDomain
    {
        private readonly DbContextOptions<InternalDomainCheckerContext> _dbContextOptions;

        public DataServiceDomain(DbContextOptions<InternalDomainCheckerContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task<int> Create(EntityDomain entityDomain)
        {
            using (var context = new InternalDomainCheckerContext(_dbContextOptions))
            {
                context.Domains.Add(entityDomain);
                await context.SaveChangesAsync();
                return entityDomain.DomainId;
            }
        }
    }
}
