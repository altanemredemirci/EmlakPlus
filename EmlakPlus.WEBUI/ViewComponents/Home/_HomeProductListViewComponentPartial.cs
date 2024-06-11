using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productService;
        private readonly IMapper _mapper;

        public _HomeProductListViewComponentPartial(IProductDetailService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll(i=>i.Product.Status==true);

            var resultProducts = _mapper.Map<List<ResultProductDetailDTO>>(products);
            return View(resultProducts);
        }
    }
}
