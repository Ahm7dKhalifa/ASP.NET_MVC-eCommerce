using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.MvcWebUI.Controllers
{
    public class MenuController : Controller
    {
        private IMenuItemService _menuItemService;
        public MenuController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        // GET: Menu
        public ActionResult Index(int id)
        {
            return View(_menuItemService.GetMenuItemByRestaurantId(id));
        }
 
    }
}