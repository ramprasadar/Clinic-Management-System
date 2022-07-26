using AspNetCoreHero.ToastNotification.Abstractions;
using CmsClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CmsClientApp.Controllers
{
    public class PatientController : Controller
    {
        
        string Baseurl = "https://cmsapi12.azurewebsites.net/";
        //Get all the List of patients
        public async Task<IActionResult> GetAllPatients()
        {
            List<Patient> PatientInfo = new List<Patient>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patients");

                if (Res.IsSuccessStatusCode)
                {
                    var PatientResponse = Res.Content.ReadAsStringAsync().Result;
                    PatientInfo = JsonConvert.DeserializeObject<List<Patient>>(PatientResponse);

                }
                return View(PatientInfo);
            }
        }
        //Adding a patient
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient p)
        {
            Patient pobj = new Patient();
            //  HttpClient obj = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Patients", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //ViewBag.Message = "Succesfully Added.";
                    pobj = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            
            return RedirectToAction("GetAllPatients");
        }
        //Edit the details of the patient
        public async Task<IActionResult> Edit(int id)
        {
            Patient p = new Patient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://cmsapi12.azurewebsites.net/api/Patients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return View(p);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient p)
        {
            Patient p1 = new Patient();
            using (var httpClient = new HttpClient())
            {
                int id = p.PatientId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/Patients/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    p1 = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            
            return RedirectToAction("GetAllPatients");
        }
        //Delete a particular patient
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["PatientId"] = id;
            Patient p = new Patient();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://cmsapi12.azurewebsites.net/api/Patients/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Patient>(apiResponse);
                }
            }
            return View(p);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Patient p)
        {
            int patientid = Convert.ToInt32(TempData["PatientId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://cmsapi12.azurewebsites.net/api/Patients/" + patientid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
           
            return RedirectToAction("GetAllPatients");
        }
    }
}
