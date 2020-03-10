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
    public class MenuItemService : IMenuItemService
    {
        private MenuItemManager _menuItemManager = new MenuItemManager(new EfMenuItemDal());

        public MenuItem Get(int MenuItemID)
        {
            return _menuItemManager.Get(MenuItemID);
        }

        public List<MenuItem> GetMenuItemByRestaurantId(int id)
        {
            return _menuItemManager.GetMenuItemByRestaurantId(id);
        }
    }
}
