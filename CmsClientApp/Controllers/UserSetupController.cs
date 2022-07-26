﻿using CmsClientApp.Models;
using CmsClientApp.Helper;
using CmsClientApp.ViewRegModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace CmsClientApp.Controllers
{
    public class UserSetupController : Controller
    {
        private IConfiguration _configuration;
       
        public UserSetupController(IConfiguration configuration)
        {          
            _configuration = configuration;
        }
        string Baseurl = "https://cmsapi12.azurewebsites.net/";
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserRegistration> UserSetupInfo = new List<UserRegistration>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups");

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserSetupInfo = JsonConvert.DeserializeObject<List<UserRegistration>>(UserSetupResponse);

                }
                return View(UserSetupInfo);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            Random rnd = new Random();
            ViewBag.captcha1 = rnd.Next(0, 20);// returns random integers
            ViewBag.captcha2 = rnd.Next(10, 20);
            ViewBag.resultCaptcha = ViewBag.captcha1 + ViewBag.captcha2;
            return View("RegisterForm");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterForm reg)
        {
            MainHelper main = new MainHelper(_configuration);
            //var EncodePassword= GetMd5Hash(reg.Password);
            //reg.Password=EncodePassword;
            UserRegistration Uobj = new UserRegistration();
            //Assign the value for this fields
            Uobj.Username = reg.Username;
            Uobj.Firstname = reg.Firstname;
            Uobj.Lastname = reg.Lastname;
            Uobj.EmailId = reg.Email;
            Uobj.Password = reg.Password;
            Uobj.ConfirmPassword = reg.ConfirmPassword;
            Uobj.SecurityQuestion = reg.SecurityQuestion;
            Uobj.Answer = reg.Answer;
            Uobj.Status = false;
            Uobj.CreationDate = DateTime.Now;
            Uobj.SecurityCode = Helper.RandomHelper.RandomString(6);



            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://cmsapi12.azurewebsites.net/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(Uobj), Encoding.UTF8, "application/json");
                if (reg.Captcha == reg.resultCaptcha)
                {
                    using (var response = await httpClient.PostAsync("api/UserSetups", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                       
                        if (response.IsSuccessStatusCode)
                        {
                            //string apiResponse = await response.Content.ReadAsStringAsync();
                            //string result = JsonConvert.DeserializeObject<string>(apiResponse);
                            try
                            {

                                //sending email to user
                                string body = "<!DOCTYPE html>" +
                                                "<html> " +
                                                    "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                                    "<h3 style=\"color:#051a80;\">Welcome </h3> " + Uobj.Username +
                                                    "<h3>Thankyou for registration!</h3>" +
                                                    "<h3>Security Code: </h3>" + Uobj.SecurityCode +
                                                    "<h4>Please click on the following link to verify your account.</h4> " +
                                                    "<a href='https://cms12.azurewebsites.net/UserSetup/Activate'>Verify</a>" +
                                                    "</body> " +
                                                "</html>";
                                                
                                
                                main.Send(_configuration["Gmail:Username"], Uobj.EmailId, "Successfully Registered!", body);                                
                                HttpContext.Session.SetString("username", Uobj.Username);
                                HttpContext.Session.SetString("purpose", "login");                              
                                return View("AccountActivate");


                            }
                            catch
                            {
                                
                                Random rnd = new Random();
                                ViewBag.captcha1 = rnd.Next(0, 20);// returns random integers >= 10 and < 19
                                ViewBag.captcha2 = rnd.Next(10, 20);
                                ViewBag.resultCaptcha = ViewBag.captcha1 + ViewBag.captcha2;
                                reg.Email = "";
                                return View("RegisterForm", reg);
                            }

                        }
                        else
                        {
                            
                            Random rnd = new Random();
                            ViewBag.captcha1 = rnd.Next(0, 20);// returns random integers >= 10 and < 19
                            ViewBag.captcha2 = rnd.Next(10, 20);
                            ViewBag.resultCaptcha = ViewBag.captcha1 + ViewBag.captcha2;

                            reg.Username = null;
                            reg.Captcha = null;
                            return View("RegisterForm", reg);
                        }

                    }
                }
                else
                {
                    Random rnd = new Random();
                    ViewBag.captcha1 = rnd.Next(0, 20);// returns random integers >= 10 and < 19
                    ViewBag.captcha2 = rnd.Next(10, 20);
                    ViewBag.resultCaptcha = ViewBag.captcha1 + ViewBag.captcha2;
                    ViewBag.captchaError = "Invalid Captcha";
                    return View("RegisterForm", reg);
                }
            }
        }
        [HttpGet]
        public IActionResult Activate()
        {

            //ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Activate(string securitycode)
        {
            List<UserRegistration> UserSetupInfo = new List<UserRegistration>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups");

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserSetupInfo = JsonConvert.DeserializeObject<List<UserRegistration>>(UserSetupResponse);

                }
            }
            UserRegistration obj = null;


            foreach (var i in UserSetupInfo)
            {

                if (i.SecurityCode == securitycode)
                {
                    int seconds = DateTime.Now.Subtract(i.CreationDate).Seconds;
                    if (seconds < 60)
                    {
                        obj = i;
                    }


                }
            }
            if (obj != null)
            {

                if (HttpContext.Session.GetString("purpose") == "login")
                {
                    obj.Status = true;
                    using (var httpClient = new HttpClient())
                    {
                        string username = obj.Username;
                        StringContent content1 = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                try
                                {
                                    string body = "Dear " + obj.Username + "\nYour account is activated!\nNow you can use your user credentials to log in to your account";
                                    MainHelper main = new MainHelper(_configuration);
                                    main.Send(_configuration["Gmail:username"], obj.EmailId, "Verification Process Done!", body);
                                   
                                    return RedirectToAction("Login", "Login");
                                }
                                catch
                                {
                                    
                                    return View();
                                }

                            }
                            else
                            {

                                return View();
                            }
                        }

                    }
                }
                else if (HttpContext.Session.GetString("purpose") == "reset")
                {
                    using (var httpClient = new HttpClient())
                    {
                        string username = obj.Username;
                        StringContent content1 = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                try
                                {
                                    //string body = "You have requested to reset your password\nNow you can update your password";
                                    //MainHelper main = new MainHelper(_configuration);
                                    //main.Send(_configuration["Gmail:username"], obj.EmailId, "Reset-Password Approved!", body);
                                    //_notyf.Success("Successfully verified", 3);
                                    HttpContext.Session.SetString("username", obj.Username);
                                    return RedirectToAction("ResetPassword", "UserSetup");

                                }
                                catch
                                {
                                    
                                    return View();
                                }

                            }
                            else
                            {
                                return View();
                            }
                        }

                    }

                }

            }
            else
            {
                ViewBag.invalidCode = "Invalid Security code!";
                return View();
            }
            return View();
        }
        public async Task<IActionResult> Resend()
        {
            UserRegistration u = new UserRegistration();
            string username = HttpContext.Session.GetString("username");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/GetUserSetup/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    u = JsonConvert.DeserializeObject<UserRegistration>(apiResponse);
                }
            }
            u.SecurityCode = Helper.RandomHelper.RandomString(6);
            u.CreationDate = DateTime.Now;

            using (var httpClient = new HttpClient())
            {

                StringContent content1 = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
                {

                }
            }
            try
            {
                string body = "Security code: " + u.SecurityCode;
                MainHelper main = new MainHelper(_configuration);
                main.Send(_configuration["Gmail:username"], u.EmailId, "New Security Code", body);
                
                return RedirectToAction("Activate");
            }
            catch
            {
                
                return View();
            }




        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            UserRegistration UserSetupInfo = new UserRegistration();
            UserSetupInfo = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups/GetUserSetup/" + username);

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserSetupInfo = JsonConvert.DeserializeObject<UserRegistration>(UserSetupResponse);

                }
                if (UserSetupInfo == null)
                {
                    ViewBag.err = "User name not exists";
                    return View();
                }
                UserSetupInfo.SecurityCode = Helper.RandomHelper.RandomString(6);
                UserSetupInfo.CreationDate = DateTime.Now;

                using (var httpClient = new HttpClient())
                {

                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(UserSetupInfo), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + UserSetupInfo.Username, content1))
                    {

                    }
                }
                try
                {
                    string body = "<!DOCTYPE html>" +
                                               "<html> " +
                                                   "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                                   "<h2 style=\"color:#051a80;\">Welcome</h2> " +
                                                   "<h3>Security Code: </h3>" + UserSetupInfo.SecurityCode +
                                                   "<h3>You can reset your password here!!</h3>" +
                                                   "<a href='https://cms12.azurewebsites.net/UserSetup/Activate'>Reset Link</a>" +
                                                   "</body> " +
                                               "</html>";
                    //string body = "Hi " + UserSetupInfo.Username + "\nSecurity Code: " + UserSetupInfo.SecurityCode;
                    MainHelper main = new MainHelper(_configuration);
                    main.Send(_configuration["Gmail:username"], UserSetupInfo.EmailId, "Reset Password", body);
                    HttpContext.Session.SetString("purpose", "reset");
                    HttpContext.Session.SetString("username", UserSetupInfo.Username);
                    //ViewBag.EmailSentMessage = "Reset link has been sent to your registered mail";
                    

                }
                catch
                {
                    
                    return View();
                }


                //return View("Activate");
                return View("Resetinfo");

            }


        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(Resetpassword obj)
        {
            UserRegistration UserSetupInfo = new UserRegistration();

            using (var client = new HttpClient())
            {
                string username = obj.Username;
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups/GetUserSetup/" + username);

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserSetupInfo = JsonConvert.DeserializeObject<UserRegistration>(UserSetupResponse);

                }

                //update your password
                UserSetupInfo.Password = obj.Newpassword;
                UserSetupInfo.ConfirmPassword=obj.Confirmpassword;


                using (var httpClient = new HttpClient())
                {

                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(UserSetupInfo), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
                    {

                    }
                }
                try
                {
                    string body = "Your password has been changed successfully!";
                    MainHelper main = new MainHelper(_configuration);
                    main.Send(_configuration["Gmail:username"], UserSetupInfo.EmailId, "Password Changed!", body);
                    
                    ViewBag.UpdateMessage = "Your password has been changed successfully";
                    return RedirectToAction("Login", "Login");

                }
                catch
                {
                    
                    return View();
                }


            }


        }
        [HttpGet]
        public IActionResult ForgotUsername()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ForgotUsername(RegisterForm reg)
        {
            List<UserRegistration> UserList = new List<UserRegistration>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups");

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserList = JsonConvert.DeserializeObject<List<UserRegistration>>(UserSetupResponse);

                }
            }

            var username = (from i in UserList
                        where i.SecurityQuestion == reg.SecurityQuestion && i.Answer == reg.Answer
                        select i.Username).FirstOrDefault();
            if (username == null)
            {
                ViewBag.errormsg = "User not found";
                return View();
            }

            UserRegistration u = new UserRegistration();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups/GetUserSetup/" + username);

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    u = JsonConvert.DeserializeObject<UserRegistration>(UserSetupResponse);

                }
                u.SecurityCode = Helper.RandomHelper.RandomString(6);
                u.CreationDate = DateTime.Now;
                using (var httpClient = new HttpClient())
                {

                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
                    {

                    }
                }

                try
                {

                    MainHelper main = new MainHelper(_configuration);
                    //string body = "Hi " + u.Username + "\nSecurity Code: " + u.SecurityCode;
                    string body = "<!DOCTYPE html>" +
                                           "<html> " +
                                               "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                               "<h2 style=\"color:#051a80;\">Successfully Verified!</h2> " +
                                               "<h3>You can reset your password here!</h3>" +
                                               "<a href='https://cms12.azurewebsites.net/UserSetup/ResetPassword'>Reset Link</a>" +
                                               "</body> " +
                                           "</html>";

                    main.Send(_configuration["Gmail:username"], u.EmailId, "Reset Password", body);
                    HttpContext.Session.SetString("purpose", "reset");
                    HttpContext.Session.SetString("username", u.Username);
                    //ViewBag.EmailSentMessage = "Reset link has been sent to your registered mail";
                    


                }
                catch
                {
                    
                    return View();
                }

                return View();
                //return View("Activate");
            }



        }


    }



    //    [HttpGet]
    //    public async Task<IActionResult> Edit(string username)
    //    {
    //        UserSetup u = new UserSetup();
    //        using (var httpClient = new HttpClient())
    //        {
    //            using (var response = await httpClient.GetAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username))
    //            {
    //                string apiResponse = await response.Content.ReadAsStringAsync();
    //                u = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
    //            }
    //        }
    //        return View(u);

    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Edit(UserSetup u)
    //    {
    //        UserSetup u1 = new UserSetup();
    //        using (var httpClient = new HttpClient())
    //        {
    //            string username = u.Username;
    //            StringContent content1 = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
    //            using (var response = await httpClient.PutAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username, content1))
    //            {
    //                string apiResponse = await response.Content.ReadAsStringAsync();
    //                ViewBag.Result = "Success";
    //                u1 = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
    //            }
    //        }
    //        _notyf.Success("Successfully Updated!", 3);
    //        return RedirectToAction("GetAllUsers");
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult> Delete(string username)
    //    {
    //        TempData["Username"] = username;
    //        UserSetup e = new UserSetup();
    //        using (var httpClient = new HttpClient())
    //        {
    //            using (var response = await httpClient.GetAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username))
    //            {
    //                string apiResponse = await response.Content.ReadAsStringAsync();
    //                e = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
    //            }
    //        }
    //        return View(e);

    //    }

    //    [HttpPost]
    //    public async Task<ActionResult> Delete(UserSetup u)
    //    {
    //        string username = (string)TempData["Username"];
    //        using (var httpClient = new HttpClient())
    //        {
    //            using (var response = await httpClient.DeleteAsync("https://cmsapi12.azurewebsites.net/api/UserSetups/" + username))
    //            {
    //                string apiResponse = await response.Content.ReadAsStringAsync();
    //            }
    //        }
    //        _notyf.Success("Successfully Deleted!", 3);
    //        return RedirectToAction("GetAllUsers");
    //    }
    //}
}
