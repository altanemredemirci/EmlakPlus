using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
    {
        return View();
    }
}
}
