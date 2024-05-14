using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult GetDistricts(int cityId)
        {
            var districts = _cityService.GetDistrictsById(cityId);
            return Json(districts);
        }
    }
}
