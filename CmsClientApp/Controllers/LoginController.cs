using AspNetCoreHero.ToastNotification.Abstractions;
using CmsClientApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CmsClientApp.Helper;

namespace CmsClientApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly CmsAPI.Data.CmsContext _db;
        
        public LoginController(CmsAPI.Data.CmsContext db)
        {
            _db = db;
           
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Login(Login l)
        {
            var PasswordHash= EncodePassword.GetMd5Hash(l.Password);
            CmsAPI.Model.UserSetup obj = (from i in _db.UserSetup
                                          where i.Username == l.Username && i.Password == PasswordHash/*l.Password*/
                                          select i).FirstOrDefault();

            if (obj != null)
            {
                if (obj.Password != l.Password)
                {
                    ModelState.AddModelError(nameof(l.ErrorMessage), "Incorrect Password");
                    return View();
                }
                string username = obj.Username;
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError(nameof(l.ErrorMessage), "Incorrect Username");
                //ViewBag.errormsg = "Incorrect Username or Password";
                return View();
            }

        }

        
    }
}
