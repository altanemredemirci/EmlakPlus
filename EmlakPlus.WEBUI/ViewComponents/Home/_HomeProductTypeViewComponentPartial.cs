using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductTypeViewComponentPartial:ViewComponent
    {
        private readonly IProductTypeService _productTypeService;

        public _HomeProductTypeViewComponentPartial(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public IViewComponentResult Invoke()
        {
            var models = _productTypeService.GetAll();
            return View(models);
        }
    }
}
