using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LennyIdentity.Identity;

namespace LennyIdentity.Controllers
{
    public class AccountController : Controller
    {

        private readonly IdentityManager IdentityManager;

        public AccountController(IdentityManager _identityManager)
        {
            IdentityManager = _identityManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var user = await IdentityManager.CheckUserAsync(UserName, Password);

            if (user == null)
            {
                //无用户返回错误
                ModelState.AddModelError(string.Empty, "用户名或密码错误!");
                return View();
            }
            //登录，在Response中设置Cookie
            await HttpContext.Authentication.SignInAsync(IdentityManager.AuthenticationScheme, user);
            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> LogOff()
        {
            //登出
            await HttpContext.Authentication.SignOutAsync(IdentityManager.AuthenticationScheme);
            return Redirect("/Account/Login");
        }
    }
}
