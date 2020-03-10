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
    public class RestaurantService : IRestaurantService
    {
        private RestaurantManager _restaurantManager = new RestaurantManager(new EfRestaurantDal());
        public List<Restaurant> GetRestaurantByCity(int id)
        {
            return _restaurantManager.GetRestaurantByCity(id);
        }
    }
}
