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
    public class RestaurantManager : IRestaurantService
    {
        private IRestaurantDal _restaurantDal;
        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public List<Restaurant> GetRestaurantByCity(int id)
        {
            return _restaurantDal.GetRestaurantByCity(id);
        }
    }
}
