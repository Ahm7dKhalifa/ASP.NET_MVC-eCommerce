using eCommerce.Entities.Model;
using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eCommerce.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IMenuItemService _menuItemService;
        private IAuthenticationService _authenticationService;
        private IOrderService _orderService;
        public CartController(IMenuItemService menuItemService, IAuthenticationService authenticationService, IOrderService orderService)
        {
            _menuItemService = menuItemService;
            _authenticationService = authenticationService;
            _orderService = orderService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddToCart(int id)
        {
            MenuItem product = _menuItemService.Get(id);
            if (GetCart().CartLines.Count==0)
            {
                if (product != null)
                {
                    GetCart().AddToCart(product, 1);
                    TempData["rname"]= GetCart().FindRestaurant(product);
                }           
            }
            
            else
            {
                if (product != null)
                {
                    if(product.Menu.Restaurant.RestaurantId.ToString() == TempData["rname"].ToString())
                    {
                        GetCart().AddToCart(product, 1);
                    }
                    else
                    {
                        return RedirectToAction("Error");
                    }
                }
            }
           
            TempData["message"] = "Added";
            return RedirectToAction("Index", new RouteValueDictionary( new { controller = "Menu", action = "Index", Id = product.Menu.RestaurantID }));

        }

        public ActionResult RemoveFromCart(int id)
        {
            MenuItem product = _menuItemService.Get(id);

            if (product != null)
            {
                GetCart().RemoveFromCart(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            GetCart().Clear();
            return RedirectToAction("Index", "Cart");
        }


        public ActionResult Error()
        {
            return View();
        }

        public PartialViewResult mGetCart()
        {
            return PartialView(GetCart());
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails()
            {
                Username = _authenticationService.GetCurrentUser(User.Identity.Name).Username,
                Address = _authenticationService.GetCurrentUser(User.Identity.Name).Address,
                Firstname = _authenticationService.GetCurrentUser(User.Identity.Name).Firstname,
                Lastname = _authenticationService.GetCurrentUser(User.Identity.Name).Lastname,
                Email = _authenticationService.GetCurrentUser(User.Identity.Name).Email,
                PhoneNumber = _authenticationService.GetCurrentUser(User.Identity.Name).PhoneNumber,
                City = _authenticationService.GetCurrentUser(User.Identity.Name).City,
                Country = _authenticationService.GetCurrentUser(User.Identity.Name).Country
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            {
                return View(entity);
            }

        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            _orderService.SaveOrder(cart, entity);
        }
    }
}