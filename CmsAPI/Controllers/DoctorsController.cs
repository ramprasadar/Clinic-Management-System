using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsAPI.Data;
using CmsAPI.Model;
using CmsAPI.Provider;

namespace CmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDocProv _prod;

        public DoctorsController(IDocProv prod)
        {
            _prod = prod;
        }

        // GET: api/Doctors
        [HttpGet]
        public ActionResult<List<Doctor>> GetDoctor()
        {
            return _prod.GetDoctor();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        [ActionName("GetDoctorById")]
        public ActionResult<Doctor> GetDoctor(int id)
        {
            return _prod.GetDoctorById(id);
        }

        ////unit testing
        //public IActionResult GetDoctorById(int id)
        //{
        //    return Ok(_prod.GetDoctorById(id));
        //}

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, Doctor doctor)
        {
            try
            {
                _prod.UpdateDoctor(id, doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_prod.DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Doctor> PostDoctor(Doctor doctor)
        {
            _prod.AddDoctor(doctor);

            return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {

            _prod.DeleteDoctor(id);
            return NoContent();
        }

        [Route("[action]/{dname}")]
        [HttpGet]
        public int DoctorIDByDoctorName(string dname)
        {
            return _prod.DoctorIDByDoctorName(dname);
        }

        [Route("[action]/{did}")]
        [HttpGet]
        public ActionResult<List<int>> VisitinghourList(int did)
        {
            return _prod.VisitinghourList(did);

        }
        [Route("[action]/{name}/{visitdate}")]
        [HttpGet]
        public ActionResult<List<int>> BookedAppointment(string name, DateTime visitdate)
        {
            return _prod.BookedAppointment(name, visitdate);

        }
    }
}
