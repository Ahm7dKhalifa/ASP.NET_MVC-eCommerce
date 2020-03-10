using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int MenuItemID { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
