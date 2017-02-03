using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddPost.Filters
{

    public class CustomAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // если пользователь не принадлежит роли admin, то он перенаправляется
            bool auth = filterContext.HttpContext.User.IsInRole("admin");
            if (!auth)
            {
           
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {

                { "controller", "Panel"}, { "action", "Index" }
                });
            }
        }
    }
}