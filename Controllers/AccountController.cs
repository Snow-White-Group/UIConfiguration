using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using UIConfiguration.Models;

namespace UIConfiguration.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Login(Guid id)
        {
            User user = _context.Users.FirstOrDefault(x => x.ID.Equals(id));
            return View(user);
        }

        [HttpPost]
        public JsonResult Login(Guid id, string username, string password)
        {
            User user = _context.Users.FirstOrDefault(x => x.ID.Equals(id));
            if (user != null && user.Password.Equals(encryptPW(password)))
            {
                Claim claim = new Claim(ClaimTypes.Name,"" + user.ID);
                var userIdentity = new ClaimsIdentity("SecureLogin");
                userIdentity.AddClaim(claim);
                HttpContext.Authentication.SignInAsync("Cookie", new ClaimsPrincipal(userIdentity),new AuthenticationProperties(){
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                    IsPersistent = false,
                    AllowRefresh = true
                });
                return Json(1);
            }
            return Json(0);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Registration(string username, string password, string passwordConfirm, string email, bool newsletter)
        {
            string securePW = encryptPW(password);

            if (_context.Users.Any(x => x.Name.Equals(username)))
            {
                return Json(1);
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

        // public async Task<JsonResult> StartRecord(string name)
        // {
        //     var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //     client.Connect(serverAddress)
        //     byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(name);
        //     client.Send(toSendBytes);
        //     var response = await client.ReceiveAsync(SocketAsyncEventArgs);
        //     return Json(response);
        // }

        public IActionResult Unauthorized()
        {
            return View();
        }

        public async Task<IActionResult> SignOff()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return View();
        }

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