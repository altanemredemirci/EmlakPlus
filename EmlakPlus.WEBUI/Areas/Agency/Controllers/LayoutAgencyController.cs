using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Areas.Agency.Controllers
{
    public class LayoutAgencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
