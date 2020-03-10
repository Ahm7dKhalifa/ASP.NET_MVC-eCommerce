using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace eCommerce.Dal.Concrete.EntityFramework
{
    public class EfRestaurantDal : IRestaurantDal
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<Restaurant> GetRestaurantByCity(int id)
        {
            var model = _context.Cities.Find(id);
            if(model == null)
            {
                throw new HttpException(404, "Page Not Found");
            }
            return _context.Restaurants.Include(m => m.City).Where(x => x.CityID==id).ToList();
        }
    }
}
