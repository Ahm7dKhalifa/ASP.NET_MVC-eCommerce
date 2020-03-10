using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dal.Abstract
{
    public interface ICityDal
    {
        List<City> GetAll();
    }
}
