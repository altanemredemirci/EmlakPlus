using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Agency
{
    public class _AgencyProductListViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _AgencyProductListViewComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var models = _productService.GetAll(i => i.AgencyId == id);
            return View(_mapper.Map<List<ResultProductDTO>>(models));
        }
    }
}