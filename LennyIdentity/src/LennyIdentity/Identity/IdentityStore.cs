using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LennyIdentity.Models;

namespace LennyIdentity.Identity
{
    public class IdentityStore : IIdentityStore
    {
        private readonly IdentityContext db;

        public IdentityStore(IdentityContext _context)
        {
            db = _context;
        }

        public Task<int> AddUserAsync(User user)
        {
            db.Add(user);
            return db.SaveChangesAsync();
        }

        public Task<bool> CheckUserNameAsync(string username)
        {
            return Task.Run(() =>
            {
                bool flag = false;
                User user = db.Users.Where(x => x.UserName == username).FirstOrDefault();
                if (user != null)
                    flag = true;
                return flag;
            });
        }

        public Task<User> GetUserAsync(string username, string password)
        {
            return Task.Run(() =>
             {
                 User user = new User();
                 user = db.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                 return user;
             });
        }

        public Task<IEnumerable<Role>> GetUserRolesAsync(int userId)
        {
            return Task.Run(() =>
            {
                List<int> roleIds = db.UserRoles.Where(x => x.UserId == userId).Select(x => x.Id).ToList();
                IEnumerable<Role> roles = db.Roles.Where(x => roleIds.Contains(x.Id)).AsEnumerable();
                return roles;   
            });
        }
    }
}
