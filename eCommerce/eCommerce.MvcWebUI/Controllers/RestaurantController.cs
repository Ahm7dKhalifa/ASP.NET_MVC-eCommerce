using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.MvcWebUI.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public ActionResult Index(int id)
        {      
            return View(_restaurantService.GetRestaurantByCity(id));
        }
    }
}