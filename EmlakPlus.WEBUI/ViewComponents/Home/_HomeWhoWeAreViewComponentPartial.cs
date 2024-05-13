using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.WhoWeAreDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeWhoWeAreViewComponentPartial:ViewComponent
    {
        private readonly IWhoWeAreService _whoWeAreService;
        private readonly IMapper _mapper;

        public _HomeWhoWeAreViewComponentPartial(IWhoWeAreService whoWeAreService, IMapper mapper)
        {
            _whoWeAreService = whoWeAreService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var whoWeAre = _whoWeAreService.GetOne();
            var model = _mapper.Map<ResultWhoWeAreDTO>(whoWeAre);
            return View(model);
        }
    }
}
