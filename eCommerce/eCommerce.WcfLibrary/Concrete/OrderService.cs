using eCommerce.Bll.Concrete;
using eCommerce.Dal.Concrete.EntityFramework;
using eCommerce.Entities.Model;
using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.WcfLibrary.Concrete
{
    public class OrderService : IOrderService
    {
        private OrderManager _orderManager = new OrderManager(new EfOrderDal());

        public OrderDetailsModel GetOrderDetails(int OrderID)
        {
            return _orderManager.GetOrderDetails(OrderID);
        }

        public List<UserOrderModel> GetOrders(string username)
        {
            return _orderManager.GetOrders(username);
        }

        public void SaveOrder(Cart cart, ShippingDetails entity)
        {
            _orderManager.SaveOrder(cart, entity);
        }
    }
}
