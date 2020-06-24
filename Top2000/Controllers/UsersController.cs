using System.Linq;
using System.Web.Mvc;
using Top2000.Helpers;

namespace Top2000.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Manage()
        {
            if (this.IsLoggedIn() && this.GetUser().IsInRole("admin"))
            {
                using (var db = new Entities())
                {
                    return View(db.Users.ToList());
                }
            }
            ViewBag.ErrorMessage = "Admin only access";
            return View("Error");
        }
    }
}