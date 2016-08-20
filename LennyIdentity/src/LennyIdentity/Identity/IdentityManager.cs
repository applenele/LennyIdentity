using LennyIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LennyIdentity.Identity
{
    public class IdentityManager
    {
        public const string AuthenticationScheme = "LennyIdentityCookie";
        private IIdentityStore IdentityStore;

        public IdentityManager(IIdentityStore iIdentityStore)
        {
            IdentityStore = iIdentityStore;
        }

        //使用用户名和密码获取用户
        public async Task<ClaimsPrincipal> CheckUserAsync(string username, string password)
        {
            var user = await IdentityStore.GetUserAsync(username, password);
            if (user == null) return null;

            var ci = CreateClaimsIdentity(user);
            var roles = await IdentityStore.GetUserRolesAsync(user.Id);
            AddRoleClaims(ci, roles.ToList());
            return new ClaimsPrincipal(ci);
        }

        //注册新用户
        public async Task<IdentityResult> RegisterAsync(string username, string password)
        {
            if (await IdentityStore.CheckUserNameAsync(username))
                return new IdentityResult("用户名已经存在!");

            var user = new User { UserName = username, Password = password };
            await IdentityStore.AddUserAsync(user);

            var ci = CreateClaimsIdentity(user);
            return new IdentityResult(new ClaimsPrincipal(ci));
        }

        #region 辅助方法

        private ClaimsIdentity CreateClaimsIdentity(User user)
        {
            //用当前用户信息创建一个ClaimsIdentity
            //AuthenticationScheme需要和Cookie中间件中AuthenticationScheme一致
            //如果添加的角色时使用的类型不是ClaimTypes.Role，则需要在此处指定类型
            //var result = new ClaimsIdentity(AuthenticationScheme,NameType,RoleType);
            var result = new ClaimsIdentity(AuthenticationScheme);
            //NameType使用自带的ClaimTypes.Name
            result.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            return result;
        }

        private void AddRoleClaims(ClaimsIdentity claimsIdentity, IList<Role> roles)
        {
            foreach (var role in roles)
            {
                //添加角色时使用自带的ClaimTypes.Role就不需要在新建ClaimsIdentity时指定角色验证类型
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }
        }

        #endregion
    }

    public class IdentityResult
    {
        public bool IsSuccess { get; }
        public string ErrorString { get; }
        public ClaimsPrincipal User { get; }

        public IdentityResult(string error)
        {
            IsSuccess = false;
            ErrorString = error;
        }

        public IdentityResult(ClaimsPrincipal user)
        {
            IsSuccess = true;
            User = user;
        }
    }
}
