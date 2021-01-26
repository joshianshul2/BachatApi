using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IOrderMasterServices
    {
        OrderMasterEntity GetOrderById(int id);
       
        IEnumerable<OrderMasterEntity> GetAllOrder();
        int CreateOrder(OrderMasterEntity OrderMasterEntity);
        bool UpdateOrder(int id, OrderMasterEntity OrderMasterEntity);
        bool DeleteOrder(int id);
    }
}
