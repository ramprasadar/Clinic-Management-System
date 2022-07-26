using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsAPI.Data;
using CmsAPI.Model;
using CmsAPI.Helper;

namespace CmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSetupsController : ControllerBase
    {
        private readonly CmsContext _context;

        public UserSetupsController(CmsContext context)
        {
            _context = context;
        }

        // GET: api/UserSetups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSetup>>> GetUserSetup()
        {
            return await _context.UserSetup.ToListAsync();
        }

        [Route("[action]/{Email}")]
        [HttpGet]
        public UserSetup GetUserSetupbyEmail(string Email)
        {
            UserSetup userSetup = (from i in _context.UserSetup.ToList()
                                   where i.EmailId == Email
                                   select i).FirstOrDefault();

            if (userSetup == null)
            {
                return userSetup;
            }

            return userSetup;
        }

        // GET: api/UserSetups/5
        [Route("[action]/{Username}")]
        [HttpGet]
        public async Task<ActionResult<UserSetup>> GetUserSetup(string Username)
        {
            var userSetup = await _context.UserSetup.FindAsync(Username);

            if (userSetup == null)
            {
                return NotFound();
            }

            return userSetup;
        }
        // PUT: api/UserSetups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Username}")]
        public async Task<IActionResult> PutUserSetup(string Username, UserSetup userSetup)
        {
            UserSetup l = userSetup;
            var PasswordHash = EncodePassword.GetMd5Hash(l.Password);
            userSetup.Password = PasswordHash;
            userSetup.ConfirmPassword = PasswordHash;
            foreach (var i in _context.UserSetup.ToList())
            {
                if (i.Username == Username)
                {

                    i.Firstname = userSetup.Firstname;
                    i.Lastname = userSetup.Lastname;
                    i.Password = userSetup.Password;
                    i.ConfirmPassword = userSetup.ConfirmPassword;
                    i.SecurityCode = userSetup.SecurityCode;
                    i.Status = userSetup.Status;
                    i.EmailId = userSetup.EmailId;
                    i.CreationDate = userSetup.CreationDate;
                    _context.SaveChanges();
                    return Ok(200);

                }

            }
            return BadRequest();
        }

        // POST: api/UserSetups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostUserSetup(UserSetup userSetup)
        {
            UserSetup l = userSetup;
            var PasswordHash = EncodePassword.GetMd5Hash(l.Password);
            userSetup.Password = PasswordHash;
            userSetup.ConfirmPassword = PasswordHash;
            try
            {
                _context.UserSetup.Add(userSetup);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                //if (UserSetupExists(userSetup.Username))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
                return e.ToString();
            }

            return "succsses";
        }
        // DELETE: api/UserSetups/5
        [HttpDelete("{Username}")]
        public async Task<IActionResult> DeleteUserSetup(string Username)
        {
            var userSetup = await _context.UserSetup.FindAsync(Username);
            if (userSetup == null)
            {
                return NotFound();
            }

            _context.UserSetup.Remove(userSetup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSetupExists(string Username)
        {
            return _context.UserSetup.Any(e => e.Password == Username);
        }
    }
}
