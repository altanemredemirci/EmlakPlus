using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.SliderDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.ProductList
{
    public class _ProductListHeaderViewComponentPartial:ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _ProductListHeaderViewComponentPartial(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ResultSliderDTO>(_sliderService.GetOne(i => i.Page == "ProductList")));
        }
    }
}
