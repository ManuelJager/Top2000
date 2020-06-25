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
            var principal = page.Session["principal"];
            return principal != null;
        }

        public static IPrincipal GetUser(this WebPageRenderingBase page)
        {
            return page.Session["principal"] as IPrincipal;
        }

        public static bool IsLoggedIn(this Controller page)
        {
            var principal = page.Session["principal"];
            return principal != null;
        }

        public static IPrincipal GetUser(this Controller page)
        {
            return page.Session["principal"] as IPrincipal;
        }
    }
}