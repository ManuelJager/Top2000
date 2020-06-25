using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using System.Web.Routing;
using Top2000.Helpers;

namespace Top2000.Attributes
{
    public class AuthSessionAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string[] AllowedRolesFilter = null;
        public string[] DisallowedRolesFilter = null;

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session.IsLoggedIn())
            {
                var user = session.GetUser();
                if (DisallowedRolesFilter != null)
                {
                    // if the user contains any of the disallowed roles, redirect
                    if (DisallowedRolesFilter.Any(role => user.IsInRole(role))) Redirect();
                }
                if (AllowedRolesFilter != null)
                {
                    // if the user contains any of the allowed roles, continue
                    if (!AllowedRolesFilter.Any(role => user.IsInRole(role))) Redirect();
                }
            }
            else Redirect();

            void Redirect()
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "Popular" },
                        { "controller", "Songs" },
                        { "parameterName", "" }
                    });
            }
        }
    }
}