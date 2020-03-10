using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICityService _cityService;
        private IRestaurantService _restaurantService;
        private IMenuItemService _menuItemService;

        public HomeController(ICityService cityService,IRestaurantService restaurantService,IMenuItemService menuItemService)
        {
            _cityService = cityService;
            _restaurantService = restaurantService;
            _menuItemService = menuItemService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        //public ActionResult Restaurants(int id)
        //{
        //    return View(_restaurantService.GetRestaurantByCity(id));
        //}

        //public ActionResult Menus(int id)
        //{
        //    return View(_menuItemService.GetMenuItemByRestaurantId(id));
        //}

    }
}