using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.SliderDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Agency
{
    public class _AgencyProductHeaderViewComponentPartial:ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _AgencyProductHeaderViewComponentPartial(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ResultSliderDTO>(_sliderService.GetOne(i => i.Page == "AgencyProduct")));
        }
    }
}
