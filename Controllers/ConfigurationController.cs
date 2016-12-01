using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIConfiguration.Controllers
{
    [Authorize]
    public class ConfigurationController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}