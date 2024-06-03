using EmlakPlus.WEBUI.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ApplicationUser applicationUser)
        {
            return View();
        }
    }
}
