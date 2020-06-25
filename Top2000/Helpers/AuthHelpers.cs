using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Top2000.Helpers
{
    public static class AuthHelpers
    {
        public static bool IsLoggedIn(this WebPageRenderingBase page)
        {
            return page.Session.IsLoggedIn();
        }

        public static IPrincipal GetUser(this WebPageRenderingBase page)
        {
            return page.Session.GetUser();
        }

        public static bool IsLoggedIn(this Controller page)
        {
            return page.Session.IsLoggedIn();
        }

        public static IPrincipal GetUser(this Controller page)
        {
            return page.Session.GetUser();
        }

        public static bool IsLoggedIn(this HttpSessionStateBase session)
        {
            var principal = session["principal"];
            return principal != null;
        }

        public static IPrincipal GetUser(this HttpSessionStateBase session)
        {
            return session["principal"] as IPrincipal;
        }
    }
}