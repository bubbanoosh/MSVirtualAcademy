using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCMusicStoreWithAuthentication.AuthData
{
    public class AuthAttribute : AuthorizeAttribute // : ActionFilterAttribute, IAuthenticationFilter
    {

        private bool localAllowed;
        public AuthAttribute(bool allowedParam)
        {
            localAllowed = allowedParam;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return localAllowed;
            }
            else
            {
                return true;
            }
        }


        //private bool _auth;

        //public void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    //Logic for authenticating a User
        //    _auth = (filterContext.ActionDescriptor.GetCustomAttributes(typeof(OverrideAuthenticationAttribute), true).Length == 0);

        //}

        //public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    var user = filterContext.HttpContext.User;

        //    if (user == null || !user.Identity.IsAuthenticated)
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    }

        //}
    }
}