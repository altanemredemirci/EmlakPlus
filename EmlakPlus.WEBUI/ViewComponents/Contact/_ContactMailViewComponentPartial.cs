using EmlakPlus.BLL.Abstract;
using EmlakPlus.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Contact
{
    public class _ContactMailViewComponentPartial:ViewComponent
    {
        private readonly IAgencyService _agencyService;

        public _ContactMailViewComponentPartial(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Agencies = _agencyService.GetAll().Select(i=> new { Id=i.Id, Name=i.Name});
            return View(new Mail());
        }
    }
}
