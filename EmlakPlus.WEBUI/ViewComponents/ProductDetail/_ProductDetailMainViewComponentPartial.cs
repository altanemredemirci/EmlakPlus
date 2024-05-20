using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.ProductDetail
{
    public class _ProductDetailMainViewComponentPartial:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IMapper _mapper;

        public _ProductDetailMainViewComponentPartial(IProductDetailService productDetailService, IMapper mapper)
        {
            _productDetailService = productDetailService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var productDetail = _productDetailService.GetById(id);
            return View(_mapper.Map<ResultProductDetailDTO>(productDetail));
        }
    }
}
