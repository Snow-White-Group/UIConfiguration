using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UIConfiguration.Models;

namespace UIConfiguration.Controllers
{
    public class RegistrationController : Controller
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (_context.Users.FirstOrDefault(x => x.ID.Equals(username)).Password.Equals(encryptPW(password)))
            {
               return RedirectToAction("Index", "Configuration");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult CreateUser(string username, string password, string passwordConfirm, string email, bool newsletter)
        {
            string securePW = encryptPW(password);

            if (_context.Users.Any(x => x.Name.Equals(username)))
            {
                return Json("Name exists already");
            }

            User user = new User()
            {
                ID = Guid.NewGuid(),
                Name = username,
                Password = securePW,
                EMail = email,
                Newsletter = newsletter
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Json(0);
        }

        // public async Task<JsonResult> StartRecord()
        // {
        //     Socket client = new Socket();
        //     var response = await client.ReceiveAsync(SocketAsyncEventArgs);
        //     return Json(response);
        // }

        private string encryptPW(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();     
                return hash;
            }
        }
    }
}