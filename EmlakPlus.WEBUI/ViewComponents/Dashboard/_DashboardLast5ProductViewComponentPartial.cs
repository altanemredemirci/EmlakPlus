using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardLast5ProductViewComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IMapper _mapper;

        public _DashboardLast5ProductViewComponentPartial(IProductDetailService productDetailService,IMapper mapper)
        {
            _productDetailService = productDetailService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var products =_productDetailService.Last5Product();

            return View(_mapper.Map<List<ResultProductDetailDTO>>(products));
        }
    }
}

