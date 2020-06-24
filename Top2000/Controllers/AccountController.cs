using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Top2000.Models;

namespace Top2000.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistration userRegistration)
        {
            using (var db = new Entities())
            {
                var duplicateEmail = db.Users
                    .Select(user => user.Email)
                    .ToList()
                    .Contains(userRegistration.Email);

                if (duplicateEmail)
                {
                    ViewBag.Message = "Duplicate mail";
                    return View();
                }

                db.Users.Add(new User
                {
                    Email = userRegistration.Email,
                    FirstName = userRegistration.FirstName,
                    LastName = userRegistration.LastName,
                    PasswordHash = ComputeSha256Hash(userRegistration.Password),
                    RoleID = 2 // User
                });

                db.SaveChanges();

                ViewBag.Message = "Success";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            using (var db = new Entities())
            {
                var userModel = db.Users
                    .Where(user => user.Email == userLogin.Email)
                    .ToList()
                    .FirstOrDefault();

                var accountExists = userModel != default;

                if (!accountExists)
                {
                    ViewBag.Message = "User doesn't exist";
                    return View();
                }

                var passwordIsCorrect = userModel
                    .PasswordHash == ComputeSha256Hash(userLogin.Password);

                if (!passwordIsCorrect)
                {
                    ViewBag.Message = "Incorrect password";
                    return View();
                }

                var roleKey = userModel
                    .Role
                    .RoleKey;

                var principal = new GenericPrincipal(
                    new GenericIdentity(userModel.FirstName),
                    new string[] { roleKey });

                Session["principal"] = principal;
            }

            ViewBag.Message = "Success";
            return View();
        }

        public ActionResult LogOut()
        {
            Session["principal"] = null;

            return View();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}