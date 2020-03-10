using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dal.Concrete.EntityFramework
{
    public class EfCityDal : ICityDal
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}
