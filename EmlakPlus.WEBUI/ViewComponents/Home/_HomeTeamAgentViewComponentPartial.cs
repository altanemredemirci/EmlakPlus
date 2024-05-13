using AutoMapper;
using EmlakPlus.BLL.Abstract;
using EmlakPlus.BLL.DTOs.AgencyDTO;
using Microsoft.AspNetCore.Mvc;

namespace EmlakPlus.WEBUI.ViewComponents.Home
{
    public class _HomeTeamAgentViewComponentPartial : ViewComponent
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public _HomeTeamAgentViewComponentPartial(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var agencies = _agencyService.GetAll(i=> i.Status==true);
            var models = _mapper.Map<List<ResultAgencyDTO>>(agencies);
            return View(models);
        }
    }
}
