using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Interfaces
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void SaveOrder(Cart cart, ShippingDetails entity);
        [OperationContract]
        List<UserOrderModel> GetOrders(string username);
        [OperationContract]
        OrderDetailsModel GetOrderDetails(int OrderID);
    }
}
