using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Dal.Concrete.EntityFramework
{
    public class EfOrderDal : IOrderDal
    {
        private DatabaseContext _context = new DatabaseContext();

        public OrderDetailsModel GetOrderDetails(int OrderID)
        {
            var order = _context.Orders.Find(OrderID);
            if (order != null)
            {
                var model = _context.Orders.Where(x => x.ID == OrderID).Select(x => new OrderDetailsModel()
                {
                    OrderID = x.ID,
                    OrderNumber = x.OrderNumber,
                    Total = x.Total,
                    OrderDate = x.OrderDate,
                    OrderState = x.OrderState,
                    Address = x.Address,
                    OrderLines = x.OrderLines.Select(m => new OrderLineModel()
                    {
                        RestaurantName = m.MenuItem.Menu.Restaurant.Name,
                        Description = m.MenuItem.MenuItemDescription,
                        ProductID = m.MenuItemID,
                        ProductName = m.MenuItem.MenuItemTitle,
                        Quantity = m.Quantity,
                        Price = m.MenuItem.MenuItemPrice
                    }).ToList()
                }).FirstOrDefault();
                return model;
            }
            else
            {
                throw new HttpException(404, "Page Not Found");
            }
        }

        public List<UserOrderModel> GetOrders(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            if(user ==null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            else
            {
                var orders = _context.Orders.Where(x => x.Username == username).Select(x => new UserOrderModel()
                {
                    ID = x.ID,
                    OrderNumber = x.OrderNumber,
                    OrderDate = x.OrderDate,
                    OrderState = x.OrderState,
                    Total = x.Total
                }).OrderByDescending(x => x.OrderDate).ToList();
                return orders;
            }
        }

        public void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "O" + (new Random().Next(11111, 99999).ToString());
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = false;
            order.Username = entity.Username;
            order.Address = entity.Address;
            order.Description = entity.Description;
            order.Country = entity.Country;
            order.City = entity.City;
            order.PaymentType = entity.PaymentType;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                OrderLine orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.MenuItem.MenuItemPrice;
                orderline.MenuItemID = pr.MenuItem.MenuItemID;
                order.OrderLines.Add(orderline);

            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
