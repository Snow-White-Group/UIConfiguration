using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UIConfiguration.Models;

namespace UIConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            //var users = _context.Users.ToList();
            //return View(users);

            var users = new List<User>();
            users.Add(new User()
            {
                Name = "Cem",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Marc",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Pete",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Henne",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Mario",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Domi",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Chris",
                EMail = "",
                Thumbnail = ""
            });
            users.Add(new User()
            {
                Name = "Leon",
                EMail = "",
                Thumbnail = ""
            });

            return View(users);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
