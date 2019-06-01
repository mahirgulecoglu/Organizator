using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Organizator.UI.Filter
{
    public class LoginFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session["Login"] == null)
            {
                filterContext.Result = new RedirectResult("~/Register/LoginHata");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}