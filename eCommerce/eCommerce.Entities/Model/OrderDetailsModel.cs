using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    public class OrderDetailsModel
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderState { get; set; }
        public string Address { get; set; }

        public List<OrderLineModel> OrderLines { get; set; }
    }

    public class OrderLineModel
    {
        public string RestaurantName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
