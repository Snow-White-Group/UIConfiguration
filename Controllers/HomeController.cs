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
            var users = _context.Users.ToList();

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
