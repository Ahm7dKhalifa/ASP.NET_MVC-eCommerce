using eCommerce.Dal.Abstract;
using eCommerce.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Dal.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticationDal
    {
        private DatabaseContext _context = new DatabaseContext();
        public User Authenticate(User user)
        {
            var userDetail = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if (userDetail != null)
            {
                return user;
            }
            else { return null; }
            
        }

        public User GetCurrentUser(string username)
        {
            var CurrentUser = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            return CurrentUser;
        }
    }
}
