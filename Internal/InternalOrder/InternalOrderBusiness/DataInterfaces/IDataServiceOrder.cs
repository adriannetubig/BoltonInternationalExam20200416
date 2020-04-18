using InternalOrderBusiness.Entities;

namespace InternalOrderBusiness.DataInterfaces
{
    public interface IDataServiceOrder
    {
        int Create(EntityOrder entityOrder);
    }
}
