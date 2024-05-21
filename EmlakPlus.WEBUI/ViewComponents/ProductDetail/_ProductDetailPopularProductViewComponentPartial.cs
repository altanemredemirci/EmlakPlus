using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.ProductDetail
{
    public class _ProductDetailPopularProductViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _ProductDetailPopularProductViewComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<ResultProductDTO>>(_productService.GetPopularAll().Take(3).ToList()));
        }
    }
}
