using System.Linq;
using System.Web.Mvc;
using Top2000.Attributes;

namespace Top2000.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [AuthSession(AllowedRolesFilter = new string[] { "admin" })]
        public ActionResult Manage()
        {
            using (var db = new Entities())
            {
                return View(db.Users.ToList());
            }
        }
    }
}