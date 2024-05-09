using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeHeaderViewComponentPartial:ViewComponent
    {
        private readonly ISliderService _sliderService;

        public _HomeHeaderViewComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_sliderService.GetAll().FirstOrDefault(i => i.Page == "Index"));
        }
    }
}
