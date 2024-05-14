using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.LayoutAdmin
{
    public class _AdminHeaderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
