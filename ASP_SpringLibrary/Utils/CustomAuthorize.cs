using ASP_SpringLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ASP_SpringLibrary.Utils
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorize(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                try
                {
                    String userName = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                                                      .Select(c => c.Value).SingleOrDefault();

                    if (role == "Cliente")
                    {
                        authorize = new Cliente().isCli(userName);
                    }
                    else if (role == "Funcionário")
                    {
                        authorize = new Funcionario().isFunc(userName);
                    }

                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Permissao.cshtml"
            };
        }


    }
}