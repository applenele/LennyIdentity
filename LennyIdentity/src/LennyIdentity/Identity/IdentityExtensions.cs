using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LennyIdentity.Identity
{
    public static class IdentityExtensions
    {
        public static IApplicationBuilder UseIdentity(this IApplicationBuilder builder, string returnUrl = "/Account/Login", int expireMin = 30)
        {
            return builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString(returnUrl),
                AuthenticationScheme = IdentityManager.AuthenticationScheme,
                CookieName = "IdentityCookie",
                ExpireTimeSpan = new TimeSpan(0, expireMin, 0)
            });
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddScoped<IIdentityStore, IdentityStore>();
            services.AddScoped<IdentityManager>();
            return services;
        }
    }


}
