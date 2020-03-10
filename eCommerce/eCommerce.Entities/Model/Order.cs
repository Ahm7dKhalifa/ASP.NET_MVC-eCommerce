using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderState { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool PaymentType { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
