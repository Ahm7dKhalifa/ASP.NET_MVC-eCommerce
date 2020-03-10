using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace eCommerce.Dal.Concrete.EntityFramework
{
    public class EfMenuItemDal : IMenuItemDal
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<MenuItem> GetMenuItemByRestaurantId(int id)
        {
            var model = _context.Restaurants.Find(id);
            if(model==null)
            {
                throw new HttpException(404, "Page Not Found");
            }
           return _context.MenuItems.Include(m=>m.Menu.Restaurant.City).Include(m=>m.Menu.Restaurant).Include(m=>m.Menu).Where(x => x.Menu.RestaurantID == id).ToList();
        }

        public MenuItem Get(int MenuItemID)
        {
            return (_context.MenuItems.Include(m => m.Menu.Restaurant).Include(m => m.Menu).FirstOrDefault(x => x.MenuItemID == MenuItemID));
        }
    }
}
