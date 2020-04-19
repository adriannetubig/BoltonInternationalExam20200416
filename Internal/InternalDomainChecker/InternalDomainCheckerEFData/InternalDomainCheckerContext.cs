using InternalDomainCheckerBusiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternalDomainCheckerEFData
{

    public class InternalDomainCheckerContext : DbContext
    {
        public InternalDomainCheckerContext(DbContextOptions<InternalDomainCheckerContext> options)
            : base(options)
        {
        }

        public DbSet<EntityDomain> Domains { get; set; }
        public DbSet<EntityDomainIpAddress> DomainIpAddresses { get; set; }
        public DbSet<EntityOpenPort> OpenPorts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
