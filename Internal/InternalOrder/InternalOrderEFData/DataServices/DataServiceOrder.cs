using InternalOrderBusiness.DataInterfaces;
using InternalOrderBusiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternalOrderEFData.DataServices
{
    public class DataServiceOrder : IDataServiceOrder
    {
        private readonly DbContextOptions<InternalOrderContext> _dbContextOptions;

        public DataServiceOrder(DbContextOptions<InternalOrderContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
        public int Create(EntityOrder entityOrder)
        {
            using (var context = new InternalOrderContext(_dbContextOptions))
            {
                context.Orders.Add(entityOrder);
                context.SaveChanges();
            }
            return entityOrder.OrderId;
        }
    }
}
