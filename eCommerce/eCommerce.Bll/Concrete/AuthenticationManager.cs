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
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;
        public AuthenticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }
        public User Authenticate(User user)
        {
            return _authenticationDal.Authenticate(user);
        }

        public User GetCurrentUser(string username)
        {
            return _authenticationDal.GetCurrentUser(username);
        }
    }
}
