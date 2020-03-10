using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Bll.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public OrderDetailsModel GetOrderDetails(int OrderID)
        {
            return _orderDal.GetOrderDetails(OrderID);
        }

        public List<UserOrderModel> GetOrders(string username)
        {
            return _orderDal.GetOrders(username);
        }

        public void SaveOrder(Cart cart, ShippingDetails entity)
        {
            _orderDal.SaveOrder(cart, entity);
        }
    }
}
