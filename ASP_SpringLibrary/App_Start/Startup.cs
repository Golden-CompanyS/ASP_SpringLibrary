using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(ASP_SpringLibrary.App_Start.Startup))]

namespace ASP_SpringLibrary.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Cliente/Login"),
                LogoutPath = new PathString("/Cliente/Logout"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30.0)
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}
