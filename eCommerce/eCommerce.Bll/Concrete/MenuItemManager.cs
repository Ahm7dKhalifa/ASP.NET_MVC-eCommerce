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
    public class MenuItemManager : IMenuItemService
    {
        private IMenuItemDal _menuItemDal;
        public MenuItemManager(IMenuItemDal menuItemDal)
        {
            _menuItemDal = menuItemDal;
        }

        public MenuItem Get(int MenuItemID)
        {
            return _menuItemDal.Get(MenuItemID);
        }

        public List<MenuItem> GetMenuItemByRestaurantId(int id)
        {
            return _menuItemDal.GetMenuItemByRestaurantId(id);
        }
    }
}
