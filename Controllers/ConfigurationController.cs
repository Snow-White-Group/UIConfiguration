using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UIConfiguration.Models;

namespace UIConfiguration.Controllers
{
    [Authorize]
    public class ConfigurationController: Controller
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.Identities.FirstOrDefault(x => x.IsAuthenticated && x.HasClaim( c => c.Type == ClaimTypes.Name)).FindFirst(ClaimTypes.Name).Value);
            User user = _context.Users.FirstOrDefault(x => x.ID.Equals(id));
            return View(user);
        }
    }
}