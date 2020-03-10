using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dal.Abstract
{
    public interface IOrderDal
    {
        void SaveOrder(Cart cart, ShippingDetails entity);
        List<UserOrderModel> GetOrders(string username);
        OrderDetailsModel GetOrderDetails(int OrderId);
    }
}
