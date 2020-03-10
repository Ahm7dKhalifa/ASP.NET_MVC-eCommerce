using eCommerce.Bll.Concrete;
using eCommerce.Dal.Concrete.EntityFramework;
using eCommerce.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eCommerce.MvcWebUI.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel _ninjectkernel;
        public NinjectControllerFactory()
        {
            _ninjectkernel = new StandardKernel();
            //AddBllBindings();
            AddServiceBindings();
        }

        private void AddBllBindings()
        {
            _ninjectkernel.Bind<ICityService>().To<CityManager>().WithConstructorArgument("cityDal", new EfCityDal());
            _ninjectkernel.Bind<IRestaurantService>().To<RestaurantManager>().WithConstructorArgument("restaurantDal", new EfRestaurantDal());
            _ninjectkernel.Bind<IMenuItemService>().To<MenuItemManager>().WithConstructorArgument("menuItemDal", new EfMenuItemDal());
            _ninjectkernel.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());
            _ninjectkernel.Bind<IOrderService>().To<OrderManager>().WithConstructorArgument("orderDal", new EfOrderDal());
        }

        private void AddServiceBindings()
        {
            _ninjectkernel.Bind<ICityService>().ToConstant(WcfProxy<ICityService>.CreateChannel());
            _ninjectkernel.Bind<IRestaurantService>().ToConstant(WcfProxy<IRestaurantService>.CreateChannel());
            _ninjectkernel.Bind<IMenuItemService>().ToConstant(WcfProxy<IMenuItemService>.CreateChannel());
            _ninjectkernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());
            _ninjectkernel.Bind<IOrderService>().ToConstant(WcfProxy<IOrderService>.CreateChannel());
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectkernel.Get(controllerType);
        }
    }
}