using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.ProductList
{
    public class _ProductListStartViewComponentPartial:ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        private readonly IMapper _mapper;

        public _ProductListStartViewComponentPartial(IProductDetailService productDetailService, IMapper mapper)
        {
            _productDetailService = productDetailService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productDetailService.GetAll(i=> i.Product.Status==true);

            var resultProducts = _mapper.Map<List<ResultProductDetailDTO>>(products);
            return View(resultProducts);
        }
    }
}
