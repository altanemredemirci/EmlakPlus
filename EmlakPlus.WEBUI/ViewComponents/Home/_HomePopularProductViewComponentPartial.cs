using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using EmlakPlus.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomePopularProductViewComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productService;
        private readonly IMapper _mapper;

        public _HomePopularProductViewComponentPartial(IProductDetailService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<ResultProductDetailDTO>>(_productService.GetAll(i=> i.Product.IsPopular==true)));
        }
    }
}