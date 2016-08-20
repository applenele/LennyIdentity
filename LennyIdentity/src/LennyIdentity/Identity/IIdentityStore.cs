using LennyIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Identity
{
    public interface IIdentityStore
    {
        Task<int> AddUserAsync(User user);
        Task<User> GetUserAsync(string username, string password);
        Task<IEnumerable<Role>> GetUserRolesAsync(int userId);
        Task<bool> CheckUserNameAsync(string username);
    }
}
