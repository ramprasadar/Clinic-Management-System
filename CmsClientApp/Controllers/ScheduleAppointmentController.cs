﻿using CmsClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CmsAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace CmsClient.Controllers
{
    public class ScheduleAppointmentController : Controller
    {
        private readonly INotyfService _notyf;
        public ScheduleAppointmentController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        string Baseurl = "https://localhost:44372/";
        //Get all the Appointments
        public async Task<IActionResult> ViewAppointments()
        {
            List<Schedule> ScheduleInfo = new List<Schedule>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Schedules");

                if (Res.IsSuccessStatusCode)
                {
                    var ScheduleResponse = Res.Content.ReadAsStringAsync().Result;
                    ScheduleInfo = JsonConvert.DeserializeObject<List<Schedule>>(ScheduleResponse);

                }
                return View(ScheduleInfo);
            }

        }
        //Booking an Appointment
        [HttpGet]
        public async Task<IActionResult> Create(string d)
        {
            List<Doctor> DoctorsList = new List<Doctor>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors");

                if (Res.IsSuccessStatusCode)
                {
                    var DoctorResponse = Res.Content.ReadAsStringAsync().Result;
                    DoctorsList = JsonConvert.DeserializeObject<List<Doctor>>(DoctorResponse);

                }
            }
            List<Patient> Patientslist = new List<Patient>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patients");

                if (Res.IsSuccessStatusCode)
                {
                    var PatientResponse = Res.Content.ReadAsStringAsync().Result;
                    Patientslist = JsonConvert.DeserializeObject<List<Patient>>(PatientResponse);

                }
            }
            //Getting a patientID from the database
            var patientid = (from p in Patientslist
                             select p.PatientId).ToList();
            ViewBag.pid = new SelectList(patientid);

            //Storing the specialization in a ViewBag
            ViewBag.specialization = d;

            //Populating doctor Names using specialization from the database
            var doctorsobj = (from k in DoctorsList
                              where k.Specialization == d
                              select k.Firstname).ToList();
            ViewBag.doctor = new SelectList(doctorsobj);

            //Storing the available list of doctor details
            var availablelist = (from a in DoctorsList
                                 where a.Specialization == d
                                 select a);
            ViewBag.availablelist = availablelist;



            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Schedule s)
        {
            Schedule sobj = new Schedule();

            //  HttpClient obj = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Schedules", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sobj = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }

            _notyf.Success("Appointment booked successfully.", 3);
            return RedirectToAction("ViewAppointments");
        }

        public async Task<IActionResult> Timeslot(string Doctorname, string VisitDate)
        {
            DateTime visitdate = DateTime.Parse(VisitDate);

            int id = 0;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors/DoctorIDByDoctorName/" + Doctorname);

                if (Res.IsSuccessStatusCode)
                {
                    var DoctorResponse = Res.Content.ReadAsStringAsync().Result;
                    id = JsonConvert.DeserializeObject<int>(DoctorResponse);

                }

            }
            //List of Doctor-Visiting Hours 
            List<int> Doctoravailability = new List<int>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors/VisitinghourList/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    var DoctorResponse = Res.Content.ReadAsStringAsync().Result;
                    Doctoravailability = JsonConvert.DeserializeObject<List<int>>(DoctorResponse);

                }

            }
            //List of Booked Appointment Time
            List<int> Appointment = new List<int>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors/BookedAppointment/" + Doctorname + "/" + VisitDate);
                if (Res.IsSuccessStatusCode)
                {
                    var ScheduleResponse = Res.Content.ReadAsStringAsync().Result;
                    Appointment = JsonConvert.DeserializeObject<List<int>>(ScheduleResponse);

                }

            }
            //List of Available slots=[Doctoravailability - Appointment]
            List<int> AvailableSlots = new List<int>();
            int starttime = Doctoravailability[0];
            int endtime = Doctoravailability[1];
            for (int currenttime = starttime; currenttime <= endtime; currenttime++)
            {

                bool allow = true; //initially set true

                foreach (int appointmenttime in Appointment)
                {
                    if (currenttime == appointmenttime)
                    {
                        allow = false;//slots are not available
                        break;
                    }
                }
                if (allow == true)//slots are available
                {
                    AvailableSlots.Add(currenttime);
                }

            }
            ViewBag.res = AvailableSlots;
            return PartialView("Timeslot");
        }

        //Cancel an Appointment
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["AppointmentId"] = id;
            Schedule s = new Schedule();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44372/api/Schedules/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }
            return View(s);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Schedule s)
        {
            int appid = Convert.ToInt32(TempData["AppointmentId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44372/api/Schedules/" + appid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            _notyf.Success("Appointment Cancelled successfully.", 3);
            return RedirectToAction("ViewAppointments");
        }
    }
}
