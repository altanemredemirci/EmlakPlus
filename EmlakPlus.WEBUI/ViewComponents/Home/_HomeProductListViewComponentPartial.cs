using EmlakPlus.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _HomeProductListViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var models = _productService.GetAll();
            return View(models);
        }
    }
}
