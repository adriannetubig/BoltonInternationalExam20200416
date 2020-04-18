using InternalOrderBusiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternalOrderEFData
{
    public class InternalOrderContext : DbContext
    {
        public InternalOrderContext(DbContextOptions<InternalOrderContext> options)
            : base(options)
        {
        }
        public DbSet<EntityOrder> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
