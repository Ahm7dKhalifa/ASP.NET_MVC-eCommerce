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
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticationManager _authenticationManager = new AuthenticationManager(new EfAuthenticationDal());
        public User Authenticate(User user)
        {
            return _authenticationManager.Authenticate(user);
        }

        public User GetCurrentUser(string username)
        {
            return _authenticationManager.GetCurrentUser(username);
        }
    }
}
