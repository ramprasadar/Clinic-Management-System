using CmsClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Controllers
{
    public class SelectDoctorController : Controller
    {
        public IActionResult SelectDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SelectDoctor(SelectDoctors s)
        {
            return RedirectToAction("Create", "ScheduleAppointment", new { d = s.SelectSpeciality });
        }
    }
}
