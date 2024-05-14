using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.LayoutAdmin
{
    public class _AdminFooterViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}