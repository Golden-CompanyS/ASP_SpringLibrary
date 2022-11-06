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
                AuthenticationType = "AppAplicationCookie",
                LoginPath = new PathString("/Usuario/Login")
            });

            //AntiForgeryConfig.UniqueClaimTypeIdentifier = "Login";
        }
    }
}
