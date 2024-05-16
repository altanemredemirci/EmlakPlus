using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            ViewBag.ProductTypeCount = _statisticService.ProductTypeCount();
            ViewBag.ActiveProductTypeCount = _statisticService.ActiveProductTypeCount();
            ViewBag.PassiveProductTypeCount = _statisticService.PassiveProductTypeCount();
            ViewBag.ProductCount = _statisticService.ProductCount();
            ViewBag.TopAgencyByProductCount = _statisticService.TopAgencyByProductCount();
            ViewBag.TopProductTypeByProductCount = _statisticService.TopProductTypeByProductCount();
            ViewBag.AvgProductBySale = _statisticService.AvgProductBySale();
            ViewBag.AvgProductByRent = _statisticService.AvgProductByRent();
            ViewBag.TopCityByProductCount = _statisticService.TopCityByProductCount();
            ViewBag.DiffrentCityCount = _statisticService.DiffrentCityCount();
            ViewBag.LastProductPrice = _statisticService.LastProductPrice();
            ViewBag.TheMostExpensiveProduct = _statisticService.TheMostExpensiveProduct();
            ViewBag.CheapestProduct = _statisticService.CheapestProduct();
            ViewBag.NewestBuildingYear = _statisticService.NewestBuildingYear();
            ViewBag.OldestBuildingYear = _statisticService.OldestBuildingYear();
            ViewBag.ActiveAgencyCount = _statisticService.ActiveAgencyCount();
            return View();
        }
    }
}
