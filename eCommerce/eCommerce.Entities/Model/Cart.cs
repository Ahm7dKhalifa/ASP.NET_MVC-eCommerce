using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Model
{
    public class Cart
    {
        private List<CartLine> _cardLines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cardLines; }
        }

        public void AddToCart(MenuItem product, int quantity)
        {
            var line = _cardLines.Where(i => i.MenuItem.MenuItemID == product.MenuItemID).FirstOrDefault();
            if (line == null)
            {
                _cardLines.Add(new CartLine() { MenuItem = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveFromCart(MenuItem product)
        {
            _cardLines.RemoveAll(i => i.MenuItem.MenuItemID == product.MenuItemID);
        }

        public int FindRestaurant(MenuItem product)
        {
            var model = _cardLines.Where(x => x.MenuItem.MenuItemID == product.MenuItemID).FirstOrDefault();
            return (model.MenuItem.Menu.Restaurant.RestaurantId);
 
        }

        public double Total()
        {
            return _cardLines.Sum(i => i.MenuItem.MenuItemPrice * i.Quantity);
        }

        public void Clear()
        {
            _cardLines.Clear();
        }
    }


    public class CartLine
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}

