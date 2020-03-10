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
    public class CityService : ICityService
    {
        private CityManager _cityManager = new CityManager(new EfCityDal());
        public List<City> GetAll()
        {
            return _cityManager.GetAll();
        }
    }
}
