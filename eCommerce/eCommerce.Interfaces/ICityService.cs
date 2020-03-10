using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Interfaces
{
    [ServiceContract]
    public interface ICityService
    {
        [OperationContract]
        List<City> GetAll();
    }
}
