using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.SliderDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeHeaderViewComponentPartial:ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _HomeHeaderViewComponentPartial(ISliderService sliderService,IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ResultSliderDTO>(_sliderService.GetOne(i => i.Page == "Index")));
        }
    }
}
