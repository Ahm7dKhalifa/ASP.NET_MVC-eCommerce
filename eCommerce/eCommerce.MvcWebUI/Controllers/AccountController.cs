using eCommerce.Entities.Model;
using eCommerce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eCommerce.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationService _authenticationService;
        private IOrderService _orderService;
        public AccountController(IAuthenticationService authenticationService, IOrderService orderService)
        {
            _authenticationService = authenticationService;
            _orderService = orderService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User validatedUser = _authenticationService.Authenticate(user);

                if (validatedUser != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "Invalid Credential");
                }
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_orderService.GetOrders(User.Identity.Name));
        }

        [Authorize]
        public ActionResult OrderDetails(int id)
        {
            return PartialView(_orderService.GetOrderDetails(id));
        }
    }
}