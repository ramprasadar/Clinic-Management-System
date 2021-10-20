using CmsClientApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsAPI.Model;
using CmsAPI.Data;


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
        public IActionResult Login(CmsAPI.Model.Login l)
        {
            CmsAPI.Model.UserSetup obj = (from i in _db.UserSetup
                        where i.Username == l.Username && i.Password == l.Password
                        select i).FirstOrDefault();

            if (obj != null)
            {
                string username = obj.Username;
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.errormsg = "Incorrect Username or Password";
                return View();
            }
            
        }
    }
}
