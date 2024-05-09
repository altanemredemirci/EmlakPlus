using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.ProductTypeDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeProductTypeViewComponentPartial:ViewComponent
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
        public _HomeProductTypeViewComponentPartial(IProductTypeService productTypeService,IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var productTypes = _productTypeService.GetAll(i=> i.Status==true);

            return View(_mapper.Map<List<ResultProductTypeDTO>>(productTypes));
        }
    }
}
