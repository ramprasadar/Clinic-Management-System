using CmsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Controllers
{
    public class CancelController : Controller
    {
        private readonly CmsContext _db;
        public CancelController(CmsContext db)
        {
            _db = db;
        }

        public IActionResult ViewAppointment()
        {
            var db1 = _db.Schedule;
            var schedule = _db.Schedule.ToList();
            return View(db1.ToList());
        }
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            var c = _db.Schedule.Find(id);
            _db.Schedule.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("ViewAppointment");
        }

    }
}
